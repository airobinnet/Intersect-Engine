using System;
using System.Collections.Generic;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.General;
using Intersect.Client.Maps;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Network.Packets.Server;

namespace Intersect.Client.Entities
{

    public class Pet : Entity
    {

        public Pet(Guid id, PetEntityPacket packet) : base(id, packet)
        {
        }

        public override EntityTypes GetEntityType()
        {
            return EntityTypes.Pet;
        }
    }

}
