using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    public GameObject howToPanel;
    public GameObject soundOnIcon;
    public GameObject soundOffIcon;
    void Start()
    {
        howToPanel.SetActive(false);
        soundOnIcon.SetActive(true);
        soundOffIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundOff()
    {
        soundOnIcon.SetActive(false);
        soundOffIcon.SetActive(true);
        //müziği kapat
    }
    
    public void SoundOn()
    {
        soundOnIcon.SetActive(true);
        soundOffIcon.SetActive(false);
        //müziği aç
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void HowToButton()
    {
        howToPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        howToPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
