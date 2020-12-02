using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldOfWords
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        [Index(IsUnique = true)]
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual UserCard UserCard { get; set; }
    }
}
