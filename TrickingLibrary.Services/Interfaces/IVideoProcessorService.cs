using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrickingLibrary.API.Services.BackgroundServices;

namespace TrickingLibrary.API.Services.Interfaces
{
    public interface IVideoProcessorService
    {
        Task ProcessAsync(string input);
    }
}
