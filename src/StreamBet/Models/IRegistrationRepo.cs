using System;
using System.Collections;
using System.Collections.Generic;

namespace StreamBet.Models
{
    public interface IRegistrationRepo
    {
        IEnumerable<Streamer> GetStreamers();
        Streamer GetStreamer(int id);
        Streamer AddStreamer(Streamer s);
        bool DeleteStreamer(int id);
    }
}
