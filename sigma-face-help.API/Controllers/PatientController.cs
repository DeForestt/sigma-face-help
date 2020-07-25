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

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody]string userName, string password)
        {
            Patient patient = new Patient();
            PatientEntity patientEntity = patient.SignIn(userName, password);
            return Ok(patientEntity);
        }
    }
}
