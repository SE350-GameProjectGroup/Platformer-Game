using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCount : MonoBehaviour
{
    public static float deadCounter;
    public Text deadCtText;
    void Start()
    {
        deadCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        deadCtText.text = "Death Count: " + deadCounter.ToString();
    }
}
