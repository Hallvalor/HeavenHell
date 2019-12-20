using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public void OnContinue()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void OnNewGame()
    {
        SaveGameData.currentSave = new SaveGameData();
        SceneManager.LoadScene("Scene1");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
