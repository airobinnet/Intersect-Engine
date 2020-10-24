using System;
using System.Collections.Generic;

namespace Intersect.Client.Entities.Events
{

    public class ItemChoice
    {

        public Guid EventId;

        public List<Guid> Items = new List<Guid>();

        public int ResponseSent;

    }

}
