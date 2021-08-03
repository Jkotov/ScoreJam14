using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winTime : MonoBehaviour
{
/*    private void Start()
    {
        SetTime(GameObject.Find("Timer").GetComponent<adfa>().time);
        Destroy(GameObject.Find("Timer"));
    }
*/
    public void SetTime(float time)
    {
        GetComponent<UnityEngine.UI.Text>().text = time.ToString();
    }
}
