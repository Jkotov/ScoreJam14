using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    private bool _isInAnotherConnection = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Connection") && other.IsTouching(GetComponent<Collider2D>()))
        {
            Debug.Log("connected");
            _isInAnotherConnection = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Connection") && other.IsTouching(GetComponent<Collider2D>()))
        {
            Debug.Log("disconnected");
            _isInAnotherConnection = false;
        }
    }

    public bool IsConnected()
    {
        return _isInAnotherConnection;
    }
}
