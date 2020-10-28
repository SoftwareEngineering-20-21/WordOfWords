using System;
using System.Collections.Generic;

namespace WorldOfWords
{
    public partial class UserCard
    {
        public int UserId { get; set; }
        public int? CardId { get; set; }
        public DateTime? AnswerDate { get; set; }
        public bool? Answer { get; set; }

        public virtual Card Card { get; set; }
        public virtual User User { get; set; }
    }
}
