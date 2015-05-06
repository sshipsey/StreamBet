using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBet.Models
{
    public class Streamer
    {
        /// <summary>
        /// Unique Identifier for streamer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Streamer name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Link to streamer's stream
        /// </summary>
        public string StreamLink { get; set; }
    }

    public class StreamerStatusModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    
    }

}
