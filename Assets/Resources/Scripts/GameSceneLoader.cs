using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    int click = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            click++;
            StartCoroutine(ClickTime());

            if (click > 1)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
    IEnumerator ClickTime()
    {
        yield return new WaitForSeconds(0.5f);
        click = 0;
    }
}