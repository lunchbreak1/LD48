using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    IEnumerator LoadAsyncScene(string scene) // launches a scene asynchronously
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void OnLaunch() // Launch the main game
    {
        StartCoroutine(LoadAsyncScene("SampleScene"));
    }

    void OnReturn() // Return to the title screen
    {
        StartCoroutine(LoadAsyncScene("Title"));
    }
}
