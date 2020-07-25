using FaceHelp.Service.Library.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FaceHelp.Service.Library.Domains
{
    public class CareGiverDataAccess
    {

        private string JsonFileName
        {
            get { return "patientData.json"; }
        }

        public void SaveCareGiver(CaregiverEntity caregiverEntity)
        {
            // Pull data from Json File
            CaregiverEntity[] caregivers = this.Pull();
            // Convert array into stack and add new user to stack.
            Stack<object> caregiverl = new Stack<object>(caregivers);
            caregiverl.Push(caregiverEntity);
            // Push data back into Json File
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(caregiverl));
        }

        public CaregiverEntity[] Pull()
        {
            // Return data from the JSON File
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<CaregiverEntity[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public CaregiverEntity PullByUP(string username, string password)
        {
            // Cycle through all Users and Output return the one with the correct username and password.
            foreach (CaregiverEntity caregiver in this.Pull())
            {
                if (caregiver.UserName == username && caregiver.Password == password)
                {
                    return caregiver;
                }
            }
            // If no such account exists, return null
            return null;
        }

        public void AddPatiantrByID(string id, string pid)
        {
            // Create a new list of users
            CaregiverEntity[] list = this.Pull();

            // find the correct caregiver and add the patcient ID to that caregivers list
            foreach (CaregiverEntity caregiver in list)
            {
                if (caregiver.UserID == id)
                {
                    caregiver.Patients.Add(pid);
                } 
            }
            // Push the new list to the Json File
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(list));
        }
    }
}