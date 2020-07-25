using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceHelp.Service.Library.Domains;
using Microsoft.AspNetCore.Mvc;

namespace sigma_face_help.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : Controller
    { 
        [HttpGet("anylize")]
        public IActionResult Anylize([FromBody] string imgUrl)
        {
            var face = new Face();
            return Ok(face.Anylize(imgUrl));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
