using System;

using Intersect.Enums;

namespace Intersect.GameObjects.Maps
{

    public class PetSpawn
    {

        public NpcSpawnDirection Direction;

        public Guid PetId;

        public int X;

        public int Y;

        public PetSpawn()
        {
        }

        public PetSpawn(PetSpawn copy)
        {
            PetId = copy.PetId;
            X = copy.X;
            Y = copy.Y;
            Direction = copy.Direction;
        }

    }

}
