using FaceHelp.Service.Library.Entities;
using FaceHelp.Service.Library.Repositories;
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

        public PatientEntity SignIn(string username, string password)
        {
            return new PatientDataAccess().PullByUP(username, password);
        }
    }
}
