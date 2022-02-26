namespace Session
{
    /// <summary>
    /// Stores all non-persistent information of a session.
    /// </summary>
    public static class SessionManager
    {
        /// <summary>
        /// Authentication token for the current player.
        /// </summary>
        internal static AuthToken token;
    }
}