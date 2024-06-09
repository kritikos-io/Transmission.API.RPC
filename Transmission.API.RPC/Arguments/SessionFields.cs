using System;
using System.Collections.Generic;
using System.Text;

namespace Transmission.API.RPC.Arguments
{
    /// <summary>
    /// Session fields
    /// </summary>
    public sealed class SessionFields
    {
        private SessionFields() { }

        public const string ALT_SPEED_DOWN = "alt-speed-down";
        public const string ALT_SPEED_ENABLED = "alt-speed-enabled";
        public const string ALT_SPEED_TIME_BEGIN = "alt-speed-time-begin";
        public const string ALT_SPEED_TIME_ENABLED = "alt-speed-time-enabled";
        public const string ALT_SPEED_TIME_END = "alt-speed-time-end";
        public const string ALT_SPEED_TIME_DAY = "alt-speed-time-day";
        public const string ALT_SPEED_UP = "alt-speed-up";
        public const string BLOCKLIST_URL = "blocklist-url";
        public const string BLOCKLIST_ENABLED = "blocklist-enabled";
        public const string BLOCKLIST_SIZE = "blocklist-size";
        public const string CACHE_SIZE_MB = "cache-size-mb";
        public const string DEFAULT_TRACKERS = "default-trackers";
        public const string DHT_ENABLED = "dht-enabled";
        public const string DOWNLOAD_DIR = "download-dir";
        public const string DOWNLOAD_DIR_FREE_SPACE = "download-dir-free-space";
        public const string DOWNLOAD_QUEUE_SIZE = "download-queue-size";
        public const string DOWNLOAD_QUEUE_ENABLED = "download-queue-enabled";
        public const string ENCRYPTION = "encryption";
        public const string IDLE_SEEDING_LIMIT = "idle-seeding-limit";
        public const string IDLE_SEEDING_LIMIT_ENABLED = "idle-seeding-limit-enabled";
        public const string INCOMPLETE_DIR = "incomplete-dir";
        public const string INCOMPLETE_DIR_ENABLED = "incomplete-dir-enabled";
        public const string LPD_ENABLED = "lpd-enabled";
        public const string PEER_LIMIT_GLOBAL = "peer-limit-global";
        public const string PEER_LIMIT_PER_TORRENT = "peer-limit-per-torrent";
        public const string PEX_ENABLED = "pex-enabled";
        public const string PEER_PORT = "peer-port";
        public const string PEER_PORT_RANDOM_ON_START = "peer-port-random-on-start";
        public const string PORT_FORWARDING_ENABLED = "port-forwarding-enabled";
        public const string QUEUE_STALLED_ENABLED = "queue-stalled-enabled";
        public const string QUEUE_STALLED_MINUTES = "queue-stalled-minutes";
        public const string RENAME_PARTIAL_FILES = "rename-partial-files";
        public const string SESSION_ID = "session-id";
        public const string SCRIPT_TORRENT_ADDED_FILENAME = "script-torrent-added-filename";
        public const string SCRIPT_TORRENT_ADDED_ENABLED = "script-torrent-added-enabled";
        public const string SCRIPT_TORRENT_DONE_FILENAME = "script-torrent-done-filename";
        public const string SCRIPT_TORRENT_DONE_ENABLED = "script-torrent-done-enabled";
        public const string SCRIPT_TORRENT_DONE_SEEDING_FILENAME = "script-torrent-done-seeding-filename";
        public const string SCRIPT_TORRENT_DONE_SEEDING_ENABLED = "script-torrent-done-seeding-enabled";
        public const string SEED_RATIO_LIMIT = "seedRatioLimit";
        public const string SEED_RATIO_LIMITED = "seedRatioLimited";
        public const string SEED_QUEUE_SIZE = "seed-queue-size";
        public const string SEED_QUEUE_ENABLED = "seed-queue-enabled";
        public const string SPEED_LIMIT_DOWN = "speed-limit-down";
        public const string SPEED_LIMIT_DOWN_ENABLED = "speed-limit-down-enabled";
        public const string SPEED_LIMIT_UP = "speed-limit-up";
        public const string SPEED_LIMIT_UP_ENABLED = "speed-limit-up-enabled";
        public const string START_ADDED_TORRENTS = "start-added-torrents";
        public const string TRASH_ORIGINAL_TORRENT_FILES = "trash-original-torrent-files";
        public const string UNITS = "units";
        public const string UTP_ENABLED = "utp-enabled";
        public const string CONFIG_DIR = "config-dir";
        public const string RPC_VERSION = "rpc-version";
        public const string RPC_VERSION_MINIMUM = "rpc-version-minimum";
        public const string RPC_VERSION_SEMVER = "rpc-version-semver";
        public const string VERSION = "version";

        public static string[] ALL_FIELDS
        {
            get
            {
                return new string[]
                {
                    #region ALL FIELDS
                    ALT_SPEED_DOWN,
                    ALT_SPEED_ENABLED,
                    ALT_SPEED_TIME_BEGIN,
                    ALT_SPEED_TIME_ENABLED,
                    ALT_SPEED_TIME_END,
                    ALT_SPEED_TIME_DAY,
                    ALT_SPEED_UP,
                    BLOCKLIST_URL,
                    BLOCKLIST_ENABLED,
                    BLOCKLIST_SIZE,
                    CACHE_SIZE_MB,
                    DEFAULT_TRACKERS,
                    DHT_ENABLED,
                    DOWNLOAD_DIR,
                    DOWNLOAD_DIR_FREE_SPACE,
                    DOWNLOAD_QUEUE_SIZE,
                    DOWNLOAD_QUEUE_ENABLED,
                    ENCRYPTION,
                    IDLE_SEEDING_LIMIT,
                    IDLE_SEEDING_LIMIT_ENABLED,
                    INCOMPLETE_DIR,
                    INCOMPLETE_DIR_ENABLED,
                    LPD_ENABLED,
                    PEER_LIMIT_GLOBAL,
                    PEER_LIMIT_PER_TORRENT,
                    PEX_ENABLED,
                    PEER_PORT,
                    PEER_PORT_RANDOM_ON_START,
                    PORT_FORWARDING_ENABLED,
                    QUEUE_STALLED_ENABLED,
                    QUEUE_STALLED_MINUTES,
                    RENAME_PARTIAL_FILES,
                    SESSION_ID,
                    SCRIPT_TORRENT_ADDED_FILENAME,
                    SCRIPT_TORRENT_ADDED_ENABLED,
                    SCRIPT_TORRENT_DONE_FILENAME,
                    SCRIPT_TORRENT_DONE_ENABLED,
                    SCRIPT_TORRENT_DONE_SEEDING_FILENAME,
                    SCRIPT_TORRENT_DONE_SEEDING_ENABLED,
                    SEED_RATIO_LIMIT,
                    SEED_RATIO_LIMITED,
                    SEED_QUEUE_SIZE,
                    SEED_QUEUE_ENABLED,
                    SPEED_LIMIT_DOWN,
                    SPEED_LIMIT_DOWN_ENABLED,
                    SPEED_LIMIT_UP,
                    SPEED_LIMIT_UP_ENABLED,
                    START_ADDED_TORRENTS,
                    TRASH_ORIGINAL_TORRENT_FILES,
                    UNITS,
                    UTP_ENABLED,
                    CONFIG_DIR,
                    RPC_VERSION,
                    RPC_VERSION_MINIMUM,
                    RPC_VERSION_SEMVER,
                    VERSION,
                    #endregion
                };
            }
        }
    }
}
