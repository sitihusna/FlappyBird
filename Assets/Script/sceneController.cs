using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    public void Ready()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
