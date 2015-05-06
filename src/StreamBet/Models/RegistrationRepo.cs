using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBet.Models
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly ApplicationDbContext _db;

        public RegistrationRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddStreamerAsync(Streamer s)
        {
            _db.Streamers.Add(s);
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
            return await _db.Streamers.SingleOrDefaultAsync(s => s.Id == id);
        }

        public IAsyncEnumerable<Streamer> GetStreamers()
        {
            return _db.Streamers.AsAsyncEnumerable();
        }
    }
}
