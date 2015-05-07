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
        private IRegistrationRepo _registrationRepo;

        public StreamersController(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }

        [HttpGet]
        public IAsyncEnumerable<Streamer> GetAllStreamers()
        {
            return _registrationRepo.GetStreamers();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStreamerById(int id)
        {
            var streamer = await _registrationRepo.GetStreamerAsync(id);
            if (streamer == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(streamer);
        }

    }
}
