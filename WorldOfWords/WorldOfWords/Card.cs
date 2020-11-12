using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldOfWords
{
    public partial class Card
    {
        public Card()
        {
            UserCard = new HashSet<UserCard>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Topic")]
        public int? TopicId { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual ICollection<UserCard> UserCard { get; set; }
    }
}
