using System;
using System.Collections.Generic;
using System.Text;

namespace FaceHelp.Service.Library.Entities
{
    class CaregiverEntity
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<PatientEntity> Patients { get; set; }
    }
}
