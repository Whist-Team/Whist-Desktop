namespace Session
{
    /// <summary>
    /// Stores all non-persistent information of a session.
    /// </summary>
    public static class SessionManager
    {
        /// <summary>
        /// The base url of the Whist Server.
        /// </summary>
        internal const string serverUrl = "http://localhost:9001/";

        /// <summary>
        /// Authentication token for the current player.
        /// </summary>
        internal static AuthToken token;

        /// <summary>
        /// The user id of the current player.
        /// </summary>
        internal static string userId;

        /// <summary>
        /// The game id of the current game;
        /// </summary>
        internal static string gameId;


        public static AuthToken GetToken()
        {
            return token;
        }

        public static string GetUserId()
        {
            return userId;
        }

        public static string GetGameId()
        {
            return gameId;
        }
    }
}