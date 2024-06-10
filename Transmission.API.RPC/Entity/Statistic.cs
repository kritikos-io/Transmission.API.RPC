#nullable enable
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transmission.API.RPC.Entity
{
    /// <summary>
    /// Statistic
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// Active torrent count
        /// </summary>
        [JsonProperty("activeTorrentCount")]
        public long? ActiveTorrentCount { get; set; }

        /// <summary>
        /// Download speed
        /// </summary>
        [JsonProperty("downloadSpeed")]
        public long? downloadSpeed{ get; set; }

        /// <summary>
        /// Paused torrent count
        /// </summary>
        [JsonProperty("pausedTorrentCount")]
        public long? pausedTorrentCount{ get; set; }

        /// <summary>
        /// Torrent count
        /// </summary>
        [JsonProperty("torrentCount")]
        public long? torrentCount{ get; set; }

        /// <summary>
        /// Upload speed
        /// </summary>
        [JsonProperty("uploadSpeed")]
        public long? uploadSpeed{ get; set; }
   
        /// <summary>
        /// Cumulative stats
        /// </summary>
        [JsonProperty("cumulative-stats")]
        public CommonStatistic? CumulativeStats { get; set; }
 
        /// <summary>
        /// Current stats
        /// </summary>
        [JsonProperty("current-stats")]
        public CommonStatistic? CurrentStats { get; set; }
    }

    /// <summary>
    /// Common statistic
    /// </summary>
    public class CommonStatistic
    {
        /// <summary>
        /// Uploaded bytes
        /// </summary>
        [JsonProperty("uploadedBytes")]
        public long? UploadedBytes{ get; set; }
        
        /// <summary>
        /// Downloaded bytes
        /// </summary>
        [JsonProperty("downloadedBytes")]
        public long? DownloadedBytes{ get; set; }

        /// <summary>
        /// Files added
        /// </summary>
        [JsonProperty("filesAdded")]
        public long? FilesAdded{ get; set; }

        /// <summary>
        /// Session count
        /// </summary>
        [JsonProperty("SessionCount")]
        public long? SessionCount{ get; set; }

        /// <summary>
        /// Seconds active
        /// </summary>
        [JsonProperty("SecondsActive")]
        public long? SecondsActive{ get; set; }
    }
}
