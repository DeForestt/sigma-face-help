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
            // only allow people over the age of 50 to be validated
            if (patient.Age > 50)
            {
                return true;
            }
            return false;
        }

        public PatientEntity SignIn(string username, string password)
        {
            // Send username and password to Data Access
            return new PatientDataAccess().PullByUP(username, password);
        }

        public void AddFaceByID(string id, FaceEntity face)
        {
            // Check Data Quality
            //...
            // send to the addFaceByIDfunction In PatientDataAccess
            PatientDataAccess dataAccess = new PatientDataAccess();
            dataAccess.AddFaceByID(id, face);
        }
    }
}
