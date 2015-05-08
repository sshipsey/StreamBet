using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StreamBet.Models;
using StreamBet.ViewModels;

namespace StreamBet.Controllers
{
    [Route("[controller]")]
    public class StreamerController : Controller
    {
        private IRegistrationRepo Repository { get; }

        public StreamerController(IRegistrationRepo repository)
        {
            this.Repository = repository;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(this.Repository.GetStreamers());
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("New")]
        public async Task<IActionResult> New(NewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var streamer = new Streamer { Name = model.Name, StreamLink = model.StreamLink };
                await this.Repository.AddStreamerAsync(streamer);
                return RedirectToAction("Index");
            }

            // If we got this far, something failed. redisplay form
            return View(model);
        }

        [HttpGet("{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var streamer = await this.Repository.GetStreamerAsync(id);
            return View(new EditViewModel { Name = streamer.Name, StreamLink = streamer.StreamLink });
        }

        [HttpPost("{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.Repository.EditStreamerAsync(id, model);
            return RedirectToAction("Index");
        }

        [HttpPost("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.Repository.DeleteStreamerAsync(id);
            return RedirectToAction("Index");
        }
    }
}
