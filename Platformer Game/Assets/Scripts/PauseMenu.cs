using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }


    public void Pause()
    {
        pauseButton.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        //pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        StartCoroutine(StartGameDelay());
    }

    public void LoadMenu(string scenename)
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(scenename);

        //menüye dön

    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator StartGameDelay()
    {

        //  Debug.Log("resume");
        // yield return new WaitForSeconds(.1f); // 3-2-1 ANİMASYONU EKLE
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        GameIsPaused = false;
        pauseButton.SetActive(true);
    }
}
