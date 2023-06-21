using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);

    }

    void Destroy()
    {
        startButton.onClick.RemoveListener(HandleStartButtonClicked);
    }

    void HandleStartButtonClicked()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
