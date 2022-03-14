using Acme.Shared.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.Data.DBRepository.Entity
{
    public class UserActivity
    {
        [ForeignKey("User")]
        public string Email { get; set; }
        [Key]
        public ActivityEnum Activity { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime StartDate { get; set; }
        public string Comments { get; set; }
        public virtual User User { get; set; }
    }
}
