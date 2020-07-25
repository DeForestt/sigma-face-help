using FaceHelp.Service.Library.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FaceHelp.Service.Library.Repositories
{
    public class PatientDataAccess
    {
        private string JsonFileName
        {
            get { return "patientData.json"; }
        }

        public void SavePatient(PatientEntity patientEntity)
        {
            object[] patients = this.Pull();
            Stack<object> patientl = new Stack<object>(patients);
            patientl.Push(patientEntity);
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(patients));
        }

        public object[] Pull()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<object[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public PatientEntity PullByUP(string username, string password)
        {
            foreach (PatientEntity patient in this.Pull())
            {
                if (patient.UserName == username && patient.Password == password)
                { 
                    return patient;
                }
            }
            return null;
        }
    }
}
