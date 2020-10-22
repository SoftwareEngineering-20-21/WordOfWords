using System;
using System.Collections.Generic;

namespace WorldOfWords
{
    public partial class Topic
    {
        public Topic()
        {
            Card = new HashSet<Card>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Card> Card { get; set; }
    }
}
