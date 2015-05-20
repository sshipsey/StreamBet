using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchAPI.Models
{
    public class TwitchConstants
    {
        /// <summary>
        /// Base 'users' Url
        /// </summary>
        public const string baseUserUrl = "http://api.twitch.tv/kraken/users/";

        /// <summary>
        /// Base 'streams' Url
        /// </summary>
        public const string baseStreamUrl = "http://api.twitch.tv/kraken/streams/";
    }
}
