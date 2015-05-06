using System;
using System.Collections.Generic;
using System.Linq;

namespace StreamBet.Models
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly StreamerDbContext _db;

        public Streamer AddStreamer(Streamer s)
        {
            _db.Streamers.Add(s);
            return s;
        }

        public bool DeleteStreamer(int id)
        {
            var streamer = _db.Streamers.FirstOrDefault(s => s.Id == id);
            if (streamer != null)
            {
                _db.Streamers.Remove(streamer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Streamer GetStreamer(int id)
        {
            var streamer = _db.Streamers.FirstOrDefault(s => s.Id == id);
            if (streamer != null)
            {
                return streamer;
            }
            else
            {
                //TODO: Fix this
                return new Streamer();
            }
        }

        public IEnumerable<Streamer> GetStreamers()
        {
            return _db.Streamers.AsEnumerable();
        }
    }
}
