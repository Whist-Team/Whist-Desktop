using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Session
{
    /// <summary>
    /// Stores a player's authentication token.
    /// </summary>
    public class AuthToken
    {
        private readonly string token;
        private readonly string type;

        /// <summary>
        /// Constructor of authentication token.
        /// </summary>
        /// <param name="token">The token string.</param>
        /// <param name="type">The authentication type as string, e.g. Bearer</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthToken([NotNull] string token, [NotNull] string type)
        {
            this.token = token ?? throw new ArgumentNullException(nameof(token));
            this.type = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// Creates a authentication token from a JSON string.
        /// </summary>
        /// <param name="jsonString">Raw json string containing a 'token' and a 'token_type' field.</param>
        /// <returns></returns>
        public static AuthToken FromString(string jsonString)
        {
            Dictionary<string, string>
                tokenDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            return new AuthToken(tokenDict["token"], tokenDict["token_type"]);
        }

        public override string ToString()
        {
            return $"{type} {token}";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || GetType() != obj.GetType())
            {
                return false;
            }

            AuthToken otherToken = (AuthToken)obj;
            return otherToken.token == token && otherToken.type == type;
        }
    }
}