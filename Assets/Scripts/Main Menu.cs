using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string homeScene;
    public string playScene;
    public GameObject OptionsScreen;
    
    

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(homeScene);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(playScene);
    }
    
    public void OpenOptions()
    {
        OptionsScreen.SetActive(true);
    }
    
    
    
    public void CloseOptions()
    {
        OptionsScreen.SetActive(false);
    }
    
    public void CreditsScreen()
    {
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}

