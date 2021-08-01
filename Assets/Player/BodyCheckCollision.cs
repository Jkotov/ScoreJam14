using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCheckCollision : MonoBehaviour
{
    private bool _isCollision;
    // Start is called before the first frame update

    public bool IsColliding()
    {
        return _isCollision;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("here");
        if (other.gameObject.CompareTag("Ground"))
            _isCollision = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("ereh");
        if (other.gameObject.CompareTag("Ground"))
            _isCollision = false;
    }
    
    
}
