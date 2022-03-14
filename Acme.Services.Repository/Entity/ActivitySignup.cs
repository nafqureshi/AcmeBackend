using Acme.Shared.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.Services.Repository.Entity
{
    public class ActivitySignup
    {
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EnumDataType(typeof(ActivityEnum))]
        public ActivityEnum Activity { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime StartDate { get; set; }
        public string Comments { get; set; }
    }
}
