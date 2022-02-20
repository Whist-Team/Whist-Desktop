using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SendData());
    }

    private IEnumerator SendData()
    {
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:9000", "test");
        yield return request.SendWebRequest();

        Debug.Log(request.result != UnityWebRequest.Result.Success ? request.error : "Upload complete!");
    }
}