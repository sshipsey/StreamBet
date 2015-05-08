using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreamBet.ViewModels;

namespace StreamBet.Models
{
    public interface IRegistrationRepo
    {
        IAsyncEnumerable<Streamer> GetStreamers();

        Task<Streamer> GetStreamerAsync(int id);

        Task AddStreamerAsync(Streamer s);

        Task EditStreamerAsync(int id, EditViewModel model);

        Task<bool> DeleteStreamerAsync(int id);
    }
}
