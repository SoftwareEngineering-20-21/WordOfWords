using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldOfWords
{
    public partial class Topic
    {
        public Topic()
        {
            Card = new HashSet<Card>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Card> Card { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
