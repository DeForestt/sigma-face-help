using FaceHelp.Service.Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaceHelp.Service.Library.Domains
{
    public class Patient
    {
        public bool ValidateData(PatientEntity patient)
        {
            if (patient.Age > 50)
            {
                return true;
            }
            return false;
        }
    }
}
