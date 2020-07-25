using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceHelp.Service.Library.Domains;
using FaceHelp.Service.Library.Entities;
using FaceHelp.Service.Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace sigma_face_help.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        // Add a new student to 
        [HttpGet("add")]
        public IActionResult AddNewPatient([FromQuery]PatientEntity patientEntity)
        {
            Patient patient = new Patient();
            patientEntity.Age = 60;
            if(patient.ValidateData(patientEntity))
            {
                var patientDataAccess = new PatientDataAccess();
                patientDataAccess.SavePatient(patientEntity);
                return Ok(patientEntity);
            }
            return Ok("Age Error");
        }

        [HttpGet("signIn")]
        public IActionResult SignIn([FromQuery]string userName, string password)
        {
            Patient patient = new Patient();
            PatientEntity patientEntity = patient.SignIn(userName, password);
            return Ok(patientEntity);
        }

        [HttpGet("facebyid")]
        public IActionResult AddFaceByID([FromQuery]string id, [FromQuery]Face face)
        {
            //ask patientController to add a face by the customer ID
            return Ok();
        }
    }
}
