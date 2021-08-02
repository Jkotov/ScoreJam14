using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winTime : MonoBehaviour
{
    private void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("Timer").GetComponent<adfa>().time.ToString();
    }
}
