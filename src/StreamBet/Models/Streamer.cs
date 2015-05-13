using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

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

        /// <summary>
        /// Live status of streamer
        /// </summary>
        [NotMapped]
        public bool IsLive { get; set; }

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
