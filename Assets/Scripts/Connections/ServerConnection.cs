using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Connections
{
    public static class ServerConnection
    {
        /// <summary>
        /// Sends a form to the requests url. Logs the response.
        /// </summary>
        /// <param name="url">Requires full URL address where the request shall be sent.
        /// The route must accept POST request.</param>
        /// <typeparam name="url">string</typeparam>
        /// <param name="form">The data inside a WWWForm.</param>
        /// <typeparam name="form">WWWForm</typeparam>
        /// <param name="callback">What should be done on a successful request.</param>
        /// <typeparam name="callback">Action with parameter: UnityWebRequest.Result</typeparam>
        /// <returns>Nothing. Further action shall be taken in the callback.</returns>
        public static IEnumerator SendForm(string url, WWWForm form, Action<UnityWebRequest.Result> callback)
        {
            UnityWebRequest request = UnityWebRequest.Post(url, form);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(request.result);
            }
            else
            {
                Debug.LogError($"Request to {url} was unsuccessful, because of: {request.error}");
            }
        }
    }
}