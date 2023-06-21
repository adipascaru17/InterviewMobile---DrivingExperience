using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string MainScene;
    public GameObject loadingScreen;
    private Text loadingText;
    public float progressSpeed = 1f;

    private void Start()
    {
        loadingText = GameObject.Find("LoadingText").GetComponent<Text>();
        // Hide the loading screen initially
        loadingScreen.SetActive(false);
        loadingText.gameObject.SetActive(false);
    }

    public void StartTransitionToMainScene()
    {
        // Activate the loading screen
        loadingScreen.SetActive(true);
        loadingText.gameObject.SetActive(true);

        // Start loading the main scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(MainScene);
        asyncLoad.allowSceneActivation = false;

        // Start a coroutine to track the loading progress
        StartCoroutine(LoadMainScene(asyncLoad));
    }

    private IEnumerator LoadMainScene(AsyncOperation asyncLoad)
    {
        float targetProgress = 0f;
        float currentProgress = 0f;

        while (!asyncLoad.isDone)
        {
            targetProgress = asyncLoad.progress;
            if (asyncLoad.progress >= 0.9f)
            {
                // Ensure the target progress is 100% for a smooth transition
                targetProgress = 1f;
            }

            // Gradually update the current progress towards the target progress
            currentProgress = Mathf.MoveTowards(currentProgress, targetProgress, progressSpeed * Time.deltaTime);

            // Update the loading text based on the current progress
            loadingText.text = "Loading: " + (currentProgress * 100f).ToString("F0") + "%";

            if (asyncLoad.progress >= 0.9f && loadingText.text == "Loading: 100%")
            {
                // Allow the scene activation when the loading text reaches 100%
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
    

