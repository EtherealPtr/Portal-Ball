using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{ 
    public void StartGame(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
