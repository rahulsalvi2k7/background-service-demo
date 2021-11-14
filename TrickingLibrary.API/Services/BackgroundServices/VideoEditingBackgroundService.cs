using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using TrickingLibrary.API.BusinessObjects;

namespace TrickingLibrary.API.Services.BackgroundServices
{
    public class VideoEditingBackgroundService : BackgroundService
    {
        private readonly ChannelReader<VideoEditingRequestBO> _channelReader;

        public VideoEditingBackgroundService(Channel<VideoEditingRequestBO> channel)
        {
            _channelReader = channel.Reader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(await _channelReader.WaitToReadAsync())
            {
                try
                {
                    var message = await _channelReader.ReadAsync();

                    var input = message.InputData;

                    if (string.IsNullOrEmpty(input?.Trim()))
                    {
                        continue;
                    }

                    Console.WriteLine($"{DateTime.UtcNow.ToString("yyyyMMddhhmmss")} Processing...{input}");

                    await Task.Delay(5000);

                    Console.WriteLine($"{DateTime.UtcNow.ToString("yyyyMMddhhmmss")} Processed...{input}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"***Error*** : {ex.Message} {ex.StackTrace}");
                }
            }
        }
    }
}
