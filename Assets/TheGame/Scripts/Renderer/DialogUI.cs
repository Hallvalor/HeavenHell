using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DialogUI : MonoBehaviour
{
    //public GameObject gameOverDialog;
    public GameObject savedInfo;
    public GameObject pauseInfo;
    public GameObject darkness;


     protected void Awake()  //Start -> all deactivated
    {
       // gameOverDialog.SetActive(false);
        savedInfo.SetActive(false);
        pauseInfo.SetActive(false);
        darkness.SetActive(false);
    }

    public void showSavedInfo()
    {
        StartCoroutine(showSavedInfoAndHide());
    }

    private IEnumerator showSavedInfoAndHide()
    {
        savedInfo.SetActive(true);
        yield return new WaitForSeconds(1f);
        savedInfo.SetActive(false);
    }

    public void togglePause()
    {
        if (pauseInfo.activeSelf) //active-> set not active
        {
            pauseInfo.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseInfo.SetActive(true);
            Time.timeScale = 0f;
            Button button = pauseInfo.GetComponentInChildren<Button>();
            EventSystem.current.SetSelectedGameObject(button.gameObject);
            button.OnSelect(null); //makes sure that the button is always red when press esc
        }
        darkness.SetActive(pauseInfo.activeSelf);
        AudioListener.pause = pauseInfo.activeSelf;
    }

    public void onBackToStartMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("Menu");
    }
}
