using System;
using System.Collections.Generic;
using System.Text;

namespace FaceHelp.Service.Library.Entities
{
    public class PatientEntity
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public List<Condition> HealthConditions { get; set; }
    }

    // Possible conditions
    public enum Condition
    {
        Arthritis,
        Hypertension,
        Glaucoma
    }
}
