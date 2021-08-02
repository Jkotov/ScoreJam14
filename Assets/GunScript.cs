using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject reyStart;
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
