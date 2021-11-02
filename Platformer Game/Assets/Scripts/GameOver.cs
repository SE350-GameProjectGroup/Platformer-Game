using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BackToMenu(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    void Update()
    {
        
    }
}
