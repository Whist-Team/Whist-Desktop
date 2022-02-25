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
        /// <param name="form">The data inside a WWWForm.</param>
        /// <returns></returns>
        /// TODO: Callback
        public static IEnumerator SendForm(string url, WWWForm form)
        {
            UnityWebRequest request = UnityWebRequest.Post(url, form);
            yield return request.SendWebRequest();
            Debug.Log(request.result != UnityWebRequest.Result.Success ? request.error : "Upload complete!");
        }
    }
}