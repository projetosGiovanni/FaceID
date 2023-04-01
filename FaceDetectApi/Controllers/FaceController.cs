using FaceDetectApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace FaceDetectApi.Controllers
{

    [Route("api/faces")]
    [ApiController]
    public class FaceController : ControllerBase
    {

        //This code is used to detect faces in an uploaded file. 
        [HttpPost("detect")] //This is an HTTP POST request to the endpoint "detect"
        public async Task<IActionResult> DetectFaces(IFormFile file, //This is the uploaded file
            [FromServices] IDetectFaceService service) //This is the service used to detect the faces
        {
            var result = await service.DetectFace(file); //This calls the service to detect the faces in the file

            return Ok(new { faceFileName = result }); //This returns the file name of the detected faces
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFaceResult([FromRoute] string fileName)
        {
            if (System.IO.File.Exists(fileName) is false)
                return NotFound();

            var bytes = await System.IO.File.ReadAllBytesAsync(fileName);

            return File(bytes, "image/jpeg");
        }

    }
}
