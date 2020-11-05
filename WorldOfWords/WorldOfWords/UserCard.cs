using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldOfWords
{
    public partial class UserCard
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Card")]
        public int? CardId { get; set; }
        public DateTime? AnswerDate { get; set; }
        public bool? Answer { get; set; }

        public virtual Card Card { get; set; }
        public virtual User User { get; set; }
    }
}
