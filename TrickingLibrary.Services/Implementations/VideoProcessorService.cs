using System.Threading.Channels;
using System.Threading.Tasks;
using TrickingLibrary.API.Services.Interfaces;
using TrickingLibrary.BusinessObjects;

namespace TrickingLibrary.API.Services.Implementations
{
    public class VideoProcessorService : IVideoProcessorService
    {
        private readonly Channel<VideoEditingRequestBO> _channel;

        public VideoProcessorService(Channel<VideoEditingRequestBO> channel)
        {
            _channel = channel;
        }

        public async Task ProcessAsync(string input)
        {
            await _channel.Writer.WriteAsync(new VideoEditingRequestBO() { InputData = input });
        }
    }
}
