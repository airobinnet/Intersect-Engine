﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using Steamworks.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intersect.Client
{
#pragma warning disable 4014
    public static class Functions
    {
        public static bool IsSteamRunning { get; set; }
        public static bool IsOverlayActive { get; set; }
        public static string UserName { get; set; }

        public static SpriteFont Font { get; private set; }
        public static string STEAM_NOT_RUNNING_ERROR_MESSAGE { get; private set; } = "Please start your steam client to receive data!";

        public static void LoadContent(ContentManager Content)
        {
            Font = Content.Load<SpriteFont>(@"Font");

            if (IsSteamRunning) UserName = ReplaceUnsupportedChars(Font, SteamClient.Name).Trim();
            else UserName = "";
        }

        /// <summary>
        /// Replaces characters not supported by your spritefont.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <param name="input">The input string.</param>
        /// <param name="replaceString">The string to replace illegal characters with.</param>
        /// <returns></returns>
        public static string ReplaceUnsupportedChars(SpriteFont font, string input, string replaceString = "")
        {
            string result = "";
            if (input == null)
            {
                return null;
            }

            foreach (char c in input)
            {
                if (font.Characters.Contains(c) || c == '\r' || c == '\n')
                {
                    result += c;
                }
                else
                {
                    result += replaceString;
                }
            }
            return result;
        }

        public static async Task<AuthTicket> startAuth(SteamId steamid)
        {
            return await SteamUser.GetAuthSessionTicketAsync();
        }

        public static async Task<List<LeaderboardEntry>> FindLeaderboard(string name, int entryCount)
        {
            var leaderboard = await SteamUserStats.FindLeaderboardAsync(name);

            if (leaderboard.HasValue) return GetLeaderboardScores(leaderboard.Value, entryCount).Result;
            else return new List<LeaderboardEntry>();
        }
        public static async Task<List<LeaderboardEntry>> GetLeaderboardScores(Leaderboard leaderboard, int entryCount)
        {
            var scores = await leaderboard.GetScoresAsync(entryCount);

            if (scores != null && scores.Length > 0) return scores.ToList();
            else return new List<LeaderboardEntry>();
        }

        public static async Task<Texture2D> GetUserImage(SteamId id, GraphicsDevice device)
        {
            var image = await SteamFriends.GetMediumAvatarAsync(id);

            if (image.HasValue)
            {
                Texture2D avatarTexture = new Texture2D(device, (int)image.Value.Width, (int)image.Value.Height, false, SurfaceFormat.Color);
                avatarTexture.SetData(image.Value.Data, 0, image.Value.Data.Length);
                return avatarTexture;
            }
            else return null;
        }

        public static async Task<int> GetPlayerCount()
        {
            return await SteamUserStats.PlayerCountAsync();
        }

        public static void SteamFriends_OnGameOverlayActivated()
        {
            IsOverlayActive = !IsOverlayActive;
        }
    }
}