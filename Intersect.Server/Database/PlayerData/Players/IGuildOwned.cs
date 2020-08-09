using System;

using Intersect.Server.Entities;

namespace Intersect.Server.Database.PlayerData.Players
{

    public interface IGuildOwned
    {

        Guid GuildId { get; }

    }

}
