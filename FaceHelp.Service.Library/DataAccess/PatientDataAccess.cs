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
            get { return Path.Combine("patientData.json"); }
        }

        public void SavePatient(PatientEntity patientEntity)
        {
            Stack<object> patients = this.Pull();
            patients.Push(patientEntity);
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(patients));
        }

        public Stack<object> Pull()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Stack<object>>(jsonFileReader.ReadToEnd(),
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
