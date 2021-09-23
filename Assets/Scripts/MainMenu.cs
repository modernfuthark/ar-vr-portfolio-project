using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject holesMenu;
    public GameObject startMenu;

    public void menuSwap(GameObject to)
    {
        holesMenu.SetActive(false);
        startMenu.SetActive(false);

        to.SetActive(true);
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void quit()
    {
        Application.Quit();
    }
}
