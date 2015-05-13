using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamBet.ViewModels;
using System.Net.Http;

namespace StreamBet.Models
{
    public class StreamerRepo : IStreamerRepo
    {
        private readonly ApplicationDbContext _db;

        public StreamerRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddStreamerAsync(Streamer s)
        {
            _db.Streamers.Add(s);
            await _db.SaveChangesAsync();
        }

        public async Task EditStreamerAsync(int id, EditViewModel model)
        {
            var streamer = await this.GetStreamerAsync(id);
            streamer.Name = model.Name;
            streamer.StreamLink = model.StreamLink;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteStreamerAsync(int id)
        {
            var streamer = await _db.Streamers.SingleOrDefaultAsync(s => s.Id == id);
            if (streamer != null)
            {
                _db.Streamers.Remove(streamer);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Streamer> GetStreamerAsync(int id)
        {
            Streamer x = await _db.Streamers.SingleOrDefaultAsync(s => s.Id == id);
            using (HttpClient cli = new HttpClient())
            {
                dynamic result = await cli.GetAsync("http://api.twitch.tv/kraken/streams/" + x.Name);

                if (result.stream != null)
                {
                    x.IsLive = true;
                }
                else
                {
                    x.IsLive = false;
                }
            }
            return x;
        }

        public IAsyncEnumerable<Streamer> GetStreamers()
        {
            return _db.Streamers.AsAsyncEnumerable();
        } 
    }
}
