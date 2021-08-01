using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    [SerializeField] private bool isRight;
    private Vector3 _otherConnectionPosition;
    private bool _isInAnotherConnection = false;
    private bool isRightOther;
    public bool IsConnected()
    {
        return _isInAnotherConnection;
    }

    public Vector3 GetPosition()
    {
        return _otherConnectionPosition;
    }

    public bool IsRightOffset()
    {
        if (isRight && isRightOther)
            return true;
        if (!isRight && !isRightOther)
            return false;
        if (isRight && !isRightOther)
            return false;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Connection") && other.IsTouching(GetComponent<Collider2D>()))
        {
            Debug.Log("connected");
            _isInAnotherConnection = true;
            _otherConnectionPosition = other.gameObject.transform.position;
            isRightOther = other.GetComponent<Connection>().isRight;
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

}
