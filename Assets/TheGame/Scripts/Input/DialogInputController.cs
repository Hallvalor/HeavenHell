using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogInputController : MonoBehaviour
{
    private DialogUI dialogUI;

    protected void Awake()
    {
        dialogUI = GetComponent<DialogUI>();
    }

    protected void Update()
    {
        //if (dialogUI.gameOverDialog.activeInHierarchy)  //gameOver
        //{
        //    if (Input.GetKeyUp(KeyCode.E))
        //    {
        //        SaveGameData.currentSave = new SaveGameData();
        //        Time.timeScale = 1f;
        //        AudioListener.pause = false;
        //        SceneManager.LoadScene("Start");
        //    }
        //}
       //else //if game is running -> escape possible
       // {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                dialogUI.togglePause();
            }
      //  }
    }
}
