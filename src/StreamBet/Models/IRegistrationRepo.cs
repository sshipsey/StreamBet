using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreamBet.Models
{
    public interface IRegistrationRepo
    {
        IAsyncEnumerable<Streamer> GetStreamers();

        Task<Streamer> GetStreamerAsync(int id);

        Task AddStreamerAsync(Streamer s);

        Task<bool> DeleteStreamerAsync(int id);
    }
}
