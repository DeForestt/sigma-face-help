using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sigma_face_help.API.Models
{
    public class PatientModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
