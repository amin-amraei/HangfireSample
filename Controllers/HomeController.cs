using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        public HomeController(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        [HttpPost]
        [Route("welcome")]
        public IActionResult Welcome(string userName)
        {
            var jobId = _backgroundJobClient.Enqueue(() => SendWelcomeMail(userName));
            return Ok($"Job Id {jobId} Completed. Welcome Mail Sent!");
        }

      
        private void SendWelcomeMail(string userName)
        {
            //Logic to Mail the user
            Console.WriteLine($"Welcome to our application, {userName}");
        }
    }    
}