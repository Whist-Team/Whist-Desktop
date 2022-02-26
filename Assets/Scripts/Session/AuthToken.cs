using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Session
{
    public class AuthToken
    {
        private readonly string token;
        private readonly string type;

        public AuthToken([NotNull] string token, [NotNull] string type)
        {
            this.token = token ?? throw new ArgumentNullException(nameof(token));
            this.type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public static AuthToken FromString(string resultString)
        {
            Dictionary<string,string> tokenDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(resultString);
            return new AuthToken(tokenDict["token"], tokenDict["token_type"]);
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