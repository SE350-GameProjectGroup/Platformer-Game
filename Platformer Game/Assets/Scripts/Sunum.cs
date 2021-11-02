using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunum : MonoBehaviour
{
    public Transform cp1;
    public Transform cp2;
    public Transform cp3;
    public Transform cp4;
    public Transform cp5;
    public Transform cp6;
    public Transform cp7;
    public Transform cp8;
    public Transform cp9;
    public Transform cp0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = cp1.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = cp2.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = cp3.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.position = cp4.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            transform.position = cp5.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            transform.position = cp6.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            transform.position = cp7.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            transform.position = cp8.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            transform.position = cp9.transform.position;
        }if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.position = cp0.transform.position;
        }
    }
}
