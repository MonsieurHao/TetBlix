using Realms;
using System;
using System.Collections.Generic;

namespace TetBlix
{   
    public class Item : RealmObject
    {   
        [PrimaryKey]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public List<Episode> Episodes { get; }
    }

    public class Episode : RealmObject
    {
        [PrimaryKey]
        public string EpId { get; set; }
        public string EpTitle { get; set; }
        public Item ShowTitle { get; set; }
        public int EpDuration { get; set; }
    }
}
