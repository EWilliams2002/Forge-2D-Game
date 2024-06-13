using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public string playScene;
    public string loadScene;
    

    public void PlayGame()
    {
        SceneManager.LoadScene(playScene);
    }

    public void LoadGameModes()
    {
        // DISCLAIMER: Actual loads the loading screen that connects
        // to server an loads the game modes screen
        SceneManager.LoadScene(loadScene);
    }
}
