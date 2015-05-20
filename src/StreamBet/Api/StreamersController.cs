using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamBet.Models;
using Microsoft.AspNet.Mvc;

namespace StreamBet.Controllers
{
    [Route("api/[controller]")]
    public class StreamersController : Controller
    {
        private IStreamerRepo _StreamerRepo;

        public StreamersController(IStreamerRepo StreamerRepo)
        {
            _StreamerRepo = StreamerRepo;
        }

        [HttpGet]
        public async Task<IAsyncEnumerable<Streamer>> GetAllStreamers()
        {
            return await _StreamerRepo.GetStreamers();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStreamerById(int id)
        {
            var streamer = await _StreamerRepo.GetStreamerAsync(id);
            if (streamer == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(streamer);
        }

    }
}
