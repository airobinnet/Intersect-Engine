using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Intersect.Client.Classes.MonoGame.Graphics;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Graphics;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.MonoGame.NativeInterop;
using Intersect.Client.ThirdParty;
using Intersect.Configuration;
using Intersect.Core;
using Intersect.Extensions;
using Intersect.Framework.Core;
using Intersect.Framework.SystemInformation;
using Microsoft.Extensions.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MathHelper = Intersect.Utilities.MathHelper;
using XNARectangle = Microsoft.Xna.Framework.Rectangle;
using XNAColor = Microsoft.Xna.Framework.Color;

namespace Intersect.Client.MonoGame.Graphics;

internal partial class MonoRenderer : GameRenderer
{
    private GraphicsDevice _graphicsDevice;

    private List<string>? _validVideoModes;

    private BasicEffect mBasicEffect;

    private readonly ContentManager mContentManager;

    private GameBlendModes mCurrentBlendmode = GameBlendModes.None;

    private GameShader mCurrentShader;

    private FloatRect mCurrentSpriteView;

    private IGameRenderTexture mCurrentTarget;

    private FloatRect mCurrentView;

    private readonly BlendState mCutoutState;

    private int mDisplayHeight;

    private bool mDisplayModeChanged;

    private int mDisplayWidth;

    private int _fps;

    private int _frames;

    private long _nextFpsTime;

    private long mFsChangedTimer = -1;

    private readonly Game mGame;

    private readonly GameWindow mGameWindow;

    private readonly GraphicsDeviceManager mGraphics;

    private bool mInitialized;

    private bool mInitializing;

    private readonly BlendState mMultiplyState;

    private readonly BlendState mNormalState;

    private DisplayMode mOldDisplayMode;

    private readonly RasterizerState mRasterizerState = new()
    {
        ScissorTestEnable = true,
    };

    private int mScreenHeight;

    private RenderTarget2D mScreenshotRenderTarget;

    private int mScreenWidth;

    private SpriteBatch mSpriteBatch;

    private bool mSpriteBatchBegan;

    public MonoRenderer(GraphicsDeviceManager graphics, ContentManager contentManager, Game monoGame)
    {
        mGame = monoGame;
        mGraphics = graphics;
        mContentManager = contentManager;

        mNormalState = new BlendState
        {
            ColorSourceBlend = Blend.SourceAlpha,
            AlphaSourceBlend = Blend.One,
            ColorDestinationBlend = Blend.InverseSourceAlpha,
            AlphaDestinationBlend = Blend.One,
            ColorBlendFunction = BlendFunction.Add,
            AlphaBlendFunction = BlendFunction.Add,
        };

        mMultiplyState = new BlendState
        {
            ColorBlendFunction = BlendFunction.Add,
            ColorSourceBlend = Blend.DestinationColor,
            ColorDestinationBlend = Blend.Zero,
        };

        mCutoutState = new BlendState
        {
            ColorBlendFunction = BlendFunction.Add,
            ColorSourceBlend = Blend.Zero,
            ColorDestinationBlend = Blend.InverseSourceAlpha,
            AlphaBlendFunction = BlendFunction.Add,
            AlphaSourceBlend = Blend.Zero,
            AlphaDestinationBlend = Blend.InverseSourceAlpha,
        };

        mGameWindow = monoGame.Window;
    }

    public override long AvailableMemory => PlatformStatistics.AvailableGPUMemory;

    public override long TotalMemory => PlatformStatistics.TotalGPUMemory;

    public IList<string> ValidVideoModes => GetValidVideoModes();

    public void UpdateGraphicsState(int width, int height, bool initial = false)
    {
        var currentDisplayMode = mGraphics.GraphicsDevice.Adapter.CurrentDisplayMode;

        if (Globals.Database.FullScreen)
        {
            var supported = false;
            foreach (var mode in mGraphics.GraphicsDevice.Adapter.SupportedDisplayModes)
            {
                if (mode.Width == width && mode.Height == height)
                {
                    supported = true;
                }
            }

            if (!supported)
            {
                Globals.Database.FullScreen = false;
                Globals.Database.SavePreferences();
                Interface.Interface.ShowAlert(
                    Strings.Errors.DisplayNotSupportedError.ToString(
                        Strings.Internals.ResolutionXByY.ToString(width, height)
                    ),
                    Strings.Errors.DisplayNotSupported
                );
            }
        }

        var isFullscreen = Globals.Database.FullScreen;
        var updateFullscreen = initial || mGraphics.IsFullScreen != isFullscreen && !isFullscreen;

        if (updateFullscreen)
        {
            mGraphics.IsFullScreen = isFullscreen;
            mGraphics.HardwareModeSwitch = !isFullscreen;
        }

        var displayBounds = Sdl2.GetDisplayBounds();
        var currentDisplayBounds = displayBounds[0];
        var currentDisplayWidth = currentDisplayBounds.w;
        var currentDisplayHeight = currentDisplayBounds.h;
        if (isFullscreen)
        {
            width = currentDisplayWidth;
            height = currentDisplayHeight;
        }

        mScreenWidth = width;
        mScreenHeight = height;
        mGraphics.PreferredBackBufferWidth = width;
        mGraphics.PreferredBackBufferHeight = height;
        mGraphics.SynchronizeWithVerticalRetrace = Globals.Database.TargetFps == 0;

        if (Globals.Database.TargetFps == 1)
        {
            mGame.TargetElapsedTime = new TimeSpan(333333);
        }
        else if (Globals.Database.TargetFps == 2)
        {
            mGame.TargetElapsedTime = new TimeSpan(333333 / 2);
        }
        else if (Globals.Database.TargetFps == 3)
        {
            mGame.TargetElapsedTime = new TimeSpan(333333 / 3);
        }
        else if (Globals.Database.TargetFps == 4)
        {
            mGame.TargetElapsedTime = new TimeSpan(333333 / 4);
        }

        mGame.IsFixedTimeStep = Globals.Database.TargetFps > 0;

        mGraphics.ApplyChanges();

        mDisplayWidth = mGraphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        mDisplayHeight = mGraphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
        if (updateFullscreen)
        {
            mGameWindow.Position = new Microsoft.Xna.Framework.Point(
                currentDisplayBounds.x + ((currentDisplayWidth - mScreenWidth) / 2),
                currentDisplayBounds.y + ((currentDisplayHeight - mScreenHeight) / 2)
            );
        }

        mOldDisplayMode = currentDisplayMode;
        if (updateFullscreen)
        {
            mFsChangedTimer = Timing.Global.MillisecondsUtc + 1000;
        }

        if (updateFullscreen)
        {
            mDisplayModeChanged = true;
        }
    }

    public override bool Begin()
    {
        if (mFsChangedTimer > -1 && mFsChangedTimer < Timing.Global.MillisecondsUtc)
        {
            mGraphics.PreferredBackBufferWidth--;
            mGraphics.ApplyChanges();
            mGraphics.PreferredBackBufferWidth++;
            mGraphics.ApplyChanges();
            mFsChangedTimer = -1;
        }

        if (mGameWindow.ClientBounds.Width != 0 &&
            mGameWindow.ClientBounds.Height != 0 &&
            (mGameWindow.ClientBounds.Width != mScreenWidth || mGameWindow.ClientBounds.Height != mScreenHeight) &&
            !mGraphics.IsFullScreen)
        {
            if (mOldDisplayMode != mGraphics.GraphicsDevice.DisplayMode)
            {
                mDisplayModeChanged = true;
            }

            UpdateGraphicsState(mScreenWidth, mScreenHeight);
        }

        return RecreateSpriteBatch();
    }

    protected override bool RecreateSpriteBatch()
    {
        if (mSpriteBatchBegan)
        {
            EndSpriteBatch();
        }

        StartSpritebatch(
            mCurrentView,
            GameBlendModes.None,
            null,
            null,
            true
        );
        return true;
    }

    public Pointf GetMouseOffset()
    {
        return new Pointf(
            mGraphics.PreferredBackBufferWidth / (float)mGameWindow.ClientBounds.Width,
            mGraphics.PreferredBackBufferHeight / (float)mGameWindow.ClientBounds.Height
        );
    }

    private void StartSpritebatch(
        FloatRect view,
        GameBlendModes mode = GameBlendModes.None,
        GameShader shader = null,
        IGameRenderTexture target = null,
        bool forced = false,
        RasterizerState rs = null,
        bool drawImmediate = false
    )
    {
        var viewsDiff = view.X != mCurrentSpriteView.X ||
                        view.Y != mCurrentSpriteView.Y ||
                        view.Width != mCurrentSpriteView.Width ||
                        view.Height != mCurrentSpriteView.Height;

        if (mode != mCurrentBlendmode ||
            shader != mCurrentShader ||
            (shader != null && shader.ValuesChanged()) ||
            target != mCurrentTarget ||
            viewsDiff ||
            forced ||
            drawImmediate ||
            !mSpriteBatchBegan)
        {
            if (mSpriteBatchBegan)
            {
                mSpriteBatch.End();
            }

            if (target != null)
            {
                _graphicsDevice?.SetRenderTarget((RenderTarget2D)target.GetTexture());
            }
            else
            {
                _graphicsDevice?.SetRenderTarget(mScreenshotRenderTarget);
            }

            var blend = mNormalState;
            Effect useEffect = null;

            switch (mode)
            {
                case GameBlendModes.None:
                    blend = mNormalState;

                    break;

                case GameBlendModes.Alpha:
                    blend = BlendState.AlphaBlend;

                    break;

                case GameBlendModes.Multiply:
                    blend = mMultiplyState;

                    break;

                case GameBlendModes.Add:
                    blend = BlendState.Additive;

                    break;

                case GameBlendModes.Opaque:
                    blend = BlendState.Opaque;

                    break;

                case GameBlendModes.Cutout:
                    blend = mCutoutState;

                    break;
            }

            if (shader != null)
            {
                useEffect = (Effect)shader.GetShader();
                shader.ResetChanged();
            }

            mSpriteBatch.Begin(
                drawImmediate ? SpriteSortMode.Immediate : SpriteSortMode.Deferred,
                blend,
                SamplerState.PointClamp,
                null,
                rs,
                useEffect,
                CreateViewMatrix(view)
            );

            mCurrentSpriteView = view;
            mCurrentBlendmode = mode;
            mCurrentShader = shader;
            mCurrentTarget = target;
            mSpriteBatchBegan = true;
        }
    }

    public override bool DisplayModeChanged()
    {
        var changed = mDisplayModeChanged;
        mDisplayModeChanged = false;

        return changed;
    }

    public void EndSpriteBatch()
    {
        if (mSpriteBatchBegan)
        {
            mSpriteBatch.End();
        }

        mSpriteBatchBegan = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XNAColor ConvertColor(Color color)
    {
        return new XNAColor(color.R, color.G, color.B, color.A);
    }

    public override void Clear(Color color)
    {
        _graphicsDevice.Clear(ConvertColor(color));
    }

    public override void DrawTileBuffer(GameTileBuffer buffer)
    {
        EndSpriteBatch();
        if (_graphicsDevice == null || buffer == null)
        {
            return;
        }

        _graphicsDevice.SetRenderTarget(mScreenshotRenderTarget);
        _graphicsDevice.BlendState = mNormalState;
        _graphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
        _graphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
        _graphicsDevice.DepthStencilState = DepthStencilState.None;
        ((MonoTileBuffer)buffer).Draw(mBasicEffect, mCurrentView);
    }

    public override void Close()
    {
    }

    protected override IGameTexture CreateWhitePixel()
    {
        Texture2D platformTexture = new(_graphicsDevice, 1, 1);
        platformTexture.SetData([XNAColor.White]);
        var gameTexture = CreateGameTextureFromPlatformTexture("system:white_1px_1px", platformTexture);
        return gameTexture;
    }

    public ContentManager GetContentManager()
    {
        return mContentManager;
    }

    public override void DrawString(
        string text,
        GameFont? gameFont,
        float x,
        float y,
        float fontScale,
        Color? fontColor,
        bool worldPos = true,
        IGameRenderTexture? renderTexture = null,
        Color? borderColor = null
    )
    {
        var font = (SpriteFont)gameFont?.GetFont();
        if (font == null)
        {
            return;
        }

        StartSpritebatch(
            mCurrentView,
            GameBlendModes.None,
            null,
            renderTexture
        );
        foreach (var chr in text)
        {
            if (!font.Characters.Contains(chr))
            {
                text = text.Replace(chr, ' ');
            }
        }

        if (borderColor != null && borderColor != Color.Transparent)
        {
            var platformBorderColor = ConvertColor(borderColor);
            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x, y - 1),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );

            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x - 1, y),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );

            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x + 1, y),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );

            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x, y + 1),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );
        }

        mSpriteBatch.DrawString(font, text, new Vector2(x, y), ConvertColor(fontColor));
    }

    public override void DrawString(
        string text,
        GameFont gameFont,
        float x,
        float y,
        float fontScale,
        Color fontColor,
        bool worldPos,
        IGameRenderTexture renderTexture,
        FloatRect clipRect,
        Color borderColor = null
    )
    {
        if (gameFont == null)
        {
            return;
        }

        x += mCurrentView.X;
        y += mCurrentView.Y;

        var font = (SpriteFont)gameFont.GetFont();
        if (font == null)
        {
            return;
        }

        var clr = ConvertColor(fontColor);

        //Copy the current scissor rect so we can restore it after
        var currentRect = mSpriteBatch.GraphicsDevice.ScissorRectangle;
        StartSpritebatch(
            mCurrentView,
            GameBlendModes.None,
            null,
            renderTexture,
            false,
            mRasterizerState,
            true
        );

        //Set the current scissor rectangle
        mSpriteBatch.GraphicsDevice.ScissorRectangle = new XNARectangle(
            (int)clipRect.X,
            (int)clipRect.Y,
            (int)clipRect.Width,
            (int)clipRect.Height
        );

        foreach (var chr in text)
        {
            if (!font.Characters.Contains(chr))
            {
                text = text.Replace(chr, ' ');
            }
        }

        if (borderColor != null && borderColor != Color.Transparent)
        {
            var platformBorderColor = ConvertColor(borderColor);
            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x, y - 1),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );

            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x - 1, y),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );

            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x + 1, y),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );

            mSpriteBatch.DrawString(
                font,
                text,
                new Vector2(x, y + 1),
                platformBorderColor,
                0f,
                Vector2.Zero,
                new Vector2(fontScale, fontScale),
                SpriteEffects.None,
                0
            );
        }

        mSpriteBatch.DrawString(
            font,
            text,
            new Vector2(x, y),
            clr,
            0f,
            Vector2.Zero,
            new Vector2(fontScale, fontScale),
            SpriteEffects.None,
            0
        );

        EndSpriteBatch();

        //Reset scissor rectangle to the saved value
        mSpriteBatch.GraphicsDevice.ScissorRectangle = currentRect;
    }

    public override GameTileBuffer CreateTileBuffer()
    {
        return new MonoTileBuffer(_graphicsDevice);
    }

    public override void DrawTexture(
        IGameTexture tex,
        float sx,
        float sy,
        float sw,
        float sh,
        float tx,
        float ty,
        float tw,
        float th,
        Color renderColor,
        IGameRenderTexture? renderTarget = null,
        GameBlendModes blendMode = GameBlendModes.None,
        GameShader? shader = null,
        float rotationDegrees = 0,
        bool isUi = false,
        bool drawImmediate = false
    )
    {
        var texture = tex?.GetTexture();
        if (texture == null)
        {
            return;
        }

        var packRotated = false;

        var pack = tex.AtlasReference;
        if (pack != null)
        {
            if (pack.IsRotated)
            {
                rotationDegrees -= 90;
                var z = tw;
                tw = th;
                th = z;

                z = sx;
                sx = pack.Bounds.Right - sy - sh;
                sy = pack.Bounds.Top + z;

                z = sw;
                sw = sh;
                sh = z;
                packRotated = true;
            }
            else
            {
                sx += pack.Bounds.X;
                sy += pack.Bounds.Y;
            }
        }

        var origin = Vector2.Zero;
        if (Math.Abs(rotationDegrees) > 0.01)
        {
            rotationDegrees = (float)(Math.PI / 180 * rotationDegrees);
            origin = new Vector2(sw / 2f, sh / 2f);

            //TODO: Optimize in terms of memory AND performance.
            var pnt = new Pointf(0, 0);
            var pnt1 = new Pointf(tw, 0);
            var pnt2 = new Pointf(0, th);
            var cntr = new Pointf(tw / 2, th / 2);

            var pntMod = Rotate(pnt, cntr, rotationDegrees);
            var pntMod2 = Rotate(pnt1, cntr, rotationDegrees);
            var pntMod3 = Rotate(pnt2, cntr, rotationDegrees);

            var width = (int)Math.Round(GetDistance(pntMod.X, pntMod.Y, pntMod2.X, pntMod2.Y));
            var height = (int)Math.Round(GetDistance(pntMod.X, pntMod.Y, pntMod3.X, pntMod3.Y));

            if (packRotated)
            {
                (width, height) = (height, width);
            }

            tx += width / 2f;
            ty += height / 2f;
        }

        // Cache the result of ConvertColor(renderColor) in a temporary variable.
        var color = ConvertColor(renderColor);

        // Use a single Draw method to avoid duplicating code.
        void Draw(FloatRect currentView, IGameRenderTexture targetObject)
        {
            StartSpritebatch(
                currentView,
                blendMode,
                shader,
                targetObject,
                false,
                null,
                drawImmediate
            );

            mSpriteBatch.Draw(
                (Texture2D)texture,
                new Vector2(tx, ty),
                new XNARectangle((int)sx, (int)sy, (int)sw, (int)sh),
                color,
                rotationDegrees,
                origin,
                new Vector2(tw / sw, th / sh),
                SpriteEffects.None,
                0
            );
        }

        if (renderTarget == null)
        {
            if (isUi)
            {
                tx += mCurrentView.X;
                ty += mCurrentView.Y;
            }

            Draw(mCurrentView, null);
        }
        else
        {
            Draw(new FloatRect(0, 0, renderTarget.Width, renderTarget.Height), renderTarget);
        }
    }

    private static double GetDistance(double x1, double y1, double x2, double y2)
    {
        var a2 = Math.Pow(x2 - x1, 2);
        var b2 = Math.Pow(y2 - y1, 2);
        var root = Math.Sqrt(a2 + b2);

        return root;
    }

    private Pointf Rotate(Pointf pnt, Pointf ctr, float angle)
    {
        return new Pointf(
            (float)(pnt.X + (ctr.X * Math.Cos(angle)) - (ctr.Y * Math.Sin(angle))),
            (float)(pnt.Y + (ctr.X * Math.Sin(angle)) + (ctr.Y * Math.Cos(angle)))
        );
    }

    protected override void DoEnd()
    {
        EndSpriteBatch();

        ++_frames;
        var now = Timing.Global.MillisecondsUtc;
        if (_nextFpsTime > now)
        {
            return;
        }

        var delta = now - _nextFpsTime;
        var scale = delta / 1000f;

        var frames = _frames;
        var scaledFrames = (int)(frames * scale);
        _fps = frames;//scaledFrames;
        _frames = 0;//Math.Max(0, frames - scaledFrames);
        _nextFpsTime = now + 1000;
        mGameWindow.Title = Strings.Main.GameName;
    }

    public override int GetFps()
    {
        return _fps;
    }

    public override int GetScreenHeight()
    {
        return mScreenHeight;
    }

    public override int GetScreenWidth()
    {
        return mScreenWidth;
    }

    public override string GetResolutionString()
    {
        return mScreenWidth + "x" + mScreenHeight;
    }

    public Resolution[] GetAllowedResolutions()
    {
        var allowedResolutions = new[]
            {
                new Resolution(800),
                new Resolution(1024, 768),
                new Resolution(1024, 720),
                new Resolution(1280, 720),
                new Resolution(1280, 768),
                new Resolution(1280, 1024),
                new Resolution(1360, 768),
                new Resolution(1366, 768),
                new Resolution(1440, 1050),
                new Resolution(1440, 900),
                new Resolution(1600, 900),
                new Resolution(1680, 1050),
                new Resolution(1920, 1080),
            }.Concat(
                _graphicsDevice.Adapter.SupportedDisplayModes
                    .Select(displayMode => new Resolution(displayMode.Width, displayMode.Height))
                    .Where(resolution => resolution is { X: >= 800, Y: >= 480 })
            )
            .Distinct()
            .Order()
            .ToArray();

        if (Steam.SteamDeck)
        {
            allowedResolutions = new[]
            {
                new Resolution(_graphicsDevice.DisplayMode.Width, _graphicsDevice.DisplayMode.Height),
            };
        }

        return allowedResolutions;
    }

    public override List<string> GetValidVideoModes()
    {
        if (_validVideoModes != null)
        {
            return _validVideoModes;
        }

        _validVideoModes = new List<string>();

        var allowedResolutions = GetAllowedResolutions();

        var displayWidth = _graphicsDevice.DisplayMode?.Width;
        var displayHeight = _graphicsDevice.DisplayMode?.Height;

        foreach (var resolution in allowedResolutions)
        {
            if (resolution.X > displayWidth)
            {
                continue;
            }

            if (resolution.Y > displayHeight)
            {
                continue;
            }

            _validVideoModes.Add(resolution.ToString());
        }

        return _validVideoModes;
    }

    public override FloatRect GetView()
    {
        return mCurrentView;
    }

    public override void Init()
    {
        if (mInitializing)
        {
            return;
        }

        mInitializing = true;

        var database = Globals.Database;
        var validVideoModes = GetValidVideoModes();

        if (database.TargetResolution < 0)
        {
            var allowedResolutions = GetAllowedResolutions();
            var currentDisplayMode = _graphicsDevice.Adapter.CurrentDisplayMode;
            var defaultResolution = allowedResolutions.LastOrDefault(
                allowedResolution => currentDisplayMode.Width != allowedResolution.X &&
                                     currentDisplayMode.Width ==
                                     allowedResolution.X * currentDisplayMode.Height / allowedResolution.Y
            );

            if (defaultResolution == default)
            {
                defaultResolution = allowedResolutions.LastOrDefault(
                    allowedResolution => allowedResolution.X * 9 / 16 == allowedResolution.Y &&
                                         allowedResolution.X < currentDisplayMode.Width &&
                                         allowedResolution.Y < currentDisplayMode.Height
                );
            }

            if (defaultResolution != default)
            {
                database.TargetResolution = allowedResolutions.IndexOf(defaultResolution);
            }
        }

        var targetResolution = MathHelper.Clamp(database.TargetResolution, 0, validVideoModes.Count - 1);

        if (targetResolution != database.TargetResolution)
        {
            Debug.Assert(database != default, "database != null");
            database.TargetResolution = targetResolution;
            database.SavePreference("Resolution", database.TargetResolution.ToString(CultureInfo.InvariantCulture));
        }

        var targetVideoMode = validVideoModes[targetResolution];
        if (!string.IsNullOrWhiteSpace(targetVideoMode) && Resolution.TryParse(targetVideoMode, out var resolution))
        {
            PreferredResolution = resolution;
        }

        mGraphics.PreferredBackBufferWidth = PreferredResolution.X;
        mGraphics.PreferredBackBufferHeight = PreferredResolution.Y;

        UpdateGraphicsState(ActiveResolution.X, ActiveResolution.Y, true);

        mInitializing = false;
    }

    public void Init(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        mBasicEffect = new BasicEffect(_graphicsDevice);
        mBasicEffect.LightingEnabled = false;
        mBasicEffect.TextureEnabled = true;
        mSpriteBatch = new SpriteBatch(_graphicsDevice);
    }

    public override GameFont LoadFont(string filename)
    {
        // Get font size from filename, format should be name_size.xnb or whatever
        var name = GameContentManager.RemoveExtension(filename)
            .Replace(Path.Combine(ClientConfiguration.ResourcesDirectory, "fonts"), "")
            .TrimStart(Path.DirectorySeparatorChar);

        // Split the name into parts
        var parts = name.Split('_');

        // Check if the font size can be extracted
        if (parts.Length < 1 || !int.TryParse(parts[parts.Length - 1], out var size))
        {
            return null;
        }

        // Concatenate the parts of the name except the last one to get the full name
        name = string.Join("_", parts.Take(parts.Length - 1));

        // Return a new MonoFont with the extracted name and size
        return new MonoFont(name, filename, size, mContentManager);
    }

    public override GameShader LoadShader(string shaderName)
    {
        return new MonoShader(shaderName, mContentManager);
    }

    public override Pointf MeasureText(string text, GameFont? gameFont, float fontScale)
    {
        var font = (SpriteFont)gameFont?.GetFont();
        if (font == null)
        {
            return Pointf.Empty;
        }

        foreach (var chr in text)
        {
            if (!font.Characters.Contains(chr))
            {
                text = text.Replace(chr, ' ');
            }
        }

        var size = font.MeasureString(text);

        return new Pointf(size.X * fontScale, size.Y * fontScale);
    }

    private Matrix CreateViewMatrix(FloatRect view)
    {
        return Matrix.CreateRotationZ(0f) *
               Matrix.CreateTranslation(-view.X, -view.Y, 0) *
               Matrix.CreateScale(new Vector3(_scale));
    }

    public override void SetView(FloatRect view)
    {
        mCurrentView = view;

        Matrix.CreateOrthographicOffCenter(
            0,
            view.Width,
            view.Height,
            0,
            0f,
            -1,
            out var projection
        );
        projection.M41 += -0.5f * projection.M11;
        projection.M42 += -0.5f * projection.M22;
        mBasicEffect.Projection = projection;
        mBasicEffect.View = CreateViewMatrix(view);
    }

    public override bool BeginScreenshot()
    {
        if (_graphicsDevice == null)
        {
            return false;
        }

        mScreenshotRenderTarget = new RenderTarget2D(
            _graphicsDevice,
            mScreenWidth,
            mScreenHeight,
            false,
            _graphicsDevice.PresentationParameters.BackBufferFormat,
            _graphicsDevice.PresentationParameters.DepthStencilFormat,
            /* For whatever reason if this isn't zero everything breaks in .NET 7 on MacOS and most Windows devices */
            0, // mGraphicsDevice.PresentationParameters.MultiSampleCount,
            RenderTargetUsage.PreserveContents
        );

        return true;
    }

    private bool WriteScreenshotRenderTargetAsPngTo(Stream stream, string? hint)
    {
        if (mScreenshotRenderTarget.IsContentLost)
        {
            return false;
        }

        try
        {
            mScreenshotRenderTarget.SaveAsPng(stream, mScreenshotRenderTarget.Width, mScreenshotRenderTarget.Height);
            return true;
        }
        catch (Exception exception)
        {
            ApplicationContext.CurrentContext.Logger.LogWarning(
                exception,
                "Exception when writing screenshot to {Target}",
                string.IsNullOrWhiteSpace(hint) ? "stream" : hint
            );
            return false;
        }
    }

    public override void EndScreenshot()
    {
        if (mScreenshotRenderTarget == null)
        {
            return;
        }

        ProcessScreenshots(WriteScreenshotRenderTargetAsPngTo);

        if (_graphicsDevice == null)
        {
            return;
        }

        var skippedFrame = mScreenshotRenderTarget;
        mScreenshotRenderTarget = null;
        _graphicsDevice.SetRenderTarget(null);

        if (!Begin())
        {
            return;
        }

        mSpriteBatch?.Draw(skippedFrame, new XNARectangle(), XNAColor.White);
        End();
    }
}