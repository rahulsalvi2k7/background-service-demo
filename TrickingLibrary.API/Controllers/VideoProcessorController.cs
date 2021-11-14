using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TrickingLibrary.API.Services.Interfaces;

namespace TrickingLibrary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoProcessorController : ControllerBase
    {
        private readonly ILogger<VideoProcessorController> _logger;
        private readonly IVideoProcessorService _videoProcessorService;

        public VideoProcessorController(ILogger<VideoProcessorController> logger, IVideoProcessorService videoProcessorService)
        {
            _logger = logger;
            _videoProcessorService = videoProcessorService;
        }

        [HttpPost]
        public async Task Process([FromBody] string data)
        {
            await _videoProcessorService.ProcessAsync(data);
        }
    }
}
