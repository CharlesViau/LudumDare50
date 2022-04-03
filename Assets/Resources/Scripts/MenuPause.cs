using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool IsJeuxArret = false;

    public GameObject arretMenu;
    void Start()
    {
        arretMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGame();
        }
    }

    // Permet au joueur de reprendre la partie
    public void Restart()
    {
        ChooseFunction(false);
    }

    // Met le jeu sur pause et offre deux options au joueur
    public void StopGame()
    {
        ChooseFunction(true);
    }

    // Fonction générale qui est présente dans l'arrêt de jeux (Restart = false / StopGame = true)
    private void ChooseFunction(bool isActive)
    {
        arretMenu.SetActive(isActive);
        Time.timeScale = isActive ? 0f : 1f;
        IsJeuxArret = isActive;
    }

    // Fonction qui permet de quitter la partie
    public void QuitterPartie()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
