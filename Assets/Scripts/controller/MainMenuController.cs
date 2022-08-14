using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Canvas InstructionsCanvas;
    bool press = false;

    private void Start()
    {
        InstructionsCanvas.enabled = false;
    }
    public void playGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
     public void ExitGame()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        InstructionsCanvas.enabled = true;
    }
}
