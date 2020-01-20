using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Social
{
        public class ModelSocial
        {
            public int VoteId { get; set; }
            public DateTime Date { get; set; }
            public int EntityId { get; set; }
            public int EntityType { get; set; }
            public string Comment { get; set; }
            public bool Cancelled { get; set; }
        }
}
