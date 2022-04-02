using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuComponent : MonoBehaviour
{
    /// <summary>
    /// Makes us continue on the next scene in the build setting
    /// </summary>
    public void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
