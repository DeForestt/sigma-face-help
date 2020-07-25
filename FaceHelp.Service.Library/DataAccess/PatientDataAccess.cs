using FaceHelp.Service.Library.Domains;
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
            // Pull data from Json File
            PatientEntity[] patients = this.Pull();
            // Convert array into stack and add new user to stack.
            Stack<object> patientl = new Stack<object>(patients);
            patientl.Push(patientEntity);
            // Push data back into Json File
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(patients));
        }

        public PatientEntity[] Pull()
        {
            // Return data from the JSON File
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<PatientEntity[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public PatientEntity PullByUP(string username, string password)
        {
            // Cycle through all Users and Output return the one with the correct username and password.
            foreach (PatientEntity patient in this.Pull())
            {
                if (patient.UserName == username && patient.Password == password)
                { 
                    return patient;
                }
            }
            // If no such account exists, return null
            return null;
        }

        public void AddFaceByID(string id, FaceEntity face)
        {
            // loop through people until ID is found

            PatientEntity[] list = this.Pull();

            foreach (PatientEntity patientEntity in list)
            {
                if (patientEntity.UserId == id)
                {
                    // Add the face to the list
                    
                    patientEntity.Face = face;
                }
            }
            // serialize to back to Jason
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(list));
        }
    }
}
