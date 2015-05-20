using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamBet.ViewModels;
using TwitchAPI.Models;

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
            Streamer st =  await _db.Streamers.SingleOrDefaultAsync(s => s.Id == id);

            Stream ss = new Stream();
            await ss.getStream(st.Name);

            if (ss.SStream != null)
            {
                st.IsLive = true;
            }
            else
            {
                st.IsLive = false;
            }

            return st;
        }
        
        public IAsyncEnumerable<Streamer> GetStreamers()
        {
            return _db.Streamers.AsAsyncEnumerable();
        } 
    }
}
