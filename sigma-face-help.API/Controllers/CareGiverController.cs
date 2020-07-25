using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceHelp.Service.Library.Domains;
using FaceHelp.Service.Library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace sigma_face_help.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareGiverController : Controller
    {
        [HttpGet("add")]
        public IActionResult AddNewCareGgiver([FromQuery]CaregiverEntity careGiverEntity)
        {
            CareGiver careGiver = new CareGiver();
            careGiver.Add(careGiverEntity);

            return Ok(careGiver);
        }

        [HttpGet("addpatientbyid")]
        public IActionResult AddPatientById([FromQuery] string ID, [FromQuery] string PID)
        {
            CareGiverDataAccess dataAccess = new CareGiverDataAccess();
            dataAccess.AddPatiantrByID(ID, PID);

            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
