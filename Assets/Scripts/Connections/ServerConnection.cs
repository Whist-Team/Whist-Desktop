using System;
using System.Collections;
using System.Text;
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
        public static IEnumerator SendForm(string url, WWWForm form, Action<DownloadHandler> callback)
        {
            UnityWebRequest request = UnityWebRequest.Post(url, form);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(request.downloadHandler);
            }
            else
            {
                Debug.LogError($"Request to {url} was unsuccessful, because of: {request.error}");
            }
        }

        public static IEnumerator SendJsonString(string url, string json, Action<DownloadHandler> callback)
        {
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(request.downloadHandler);
            }
            else
            {
                Debug.LogError($"Request to {url} was unsuccessful, because of: {request.error}");
            }
        }
    }
}