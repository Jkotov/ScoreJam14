using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool moveable = false;
    // for moveable platforms
    [SerializeField] private float rotationSpeed;
    private Camera _camera;
    private bool _rotatable;
    private bool _followingMouse = false;
    private Vector3 _prevMousePos;
    private Vector3 _deltaMouse;
    private Connection[] _connections;
    private bool _isConnected = false;
    private bool _awaked = false;
    void Start()
    {
        _rotatable = moveable;
        _camera = Camera.main;
        _connections = GetComponentsInChildren<Connection>();
    }

    void LateUpdate()
    {
        if (!_isConnected && !_followingMouse && _awaked)
        {
            foreach (var connection in _connections)
            {
                if (connection.IsConnected())
                {
                    _isConnected = true;
                    transform.rotation = Quaternion.identity;
                    Vector3 newPosition = connection.GetPosition();
                    if (connection.IsRightOffset())
                    {
                        newPosition.x += GetComponent<BoxCollider2D>().size.x / 2 * transform.localScale.x;
                    }
                    else
                    {
                        newPosition.x -= GetComponent<BoxCollider2D>().size.x / 2 * transform.localScale.x;
                    }
                    transform.position = newPosition;
                    moveable = false;
                    GetComponent<BoxCollider2D>().isTrigger = false;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    break ;
                }
            }
        }

        if (moveable && _rotatable)
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        if (_followingMouse)
        {
            _deltaMouse = _camera.ScreenToWorldPoint(Input.mousePosition) - _prevMousePos;
            transform.position += _deltaMouse;
            _prevMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (_awaked && !_isConnected && !_followingMouse)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    

    private void OnMouseDown()
    {
        if (moveable)
        {
            _rotatable = false;
            _followingMouse = true;
            _prevMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnMouseUp()
    {
        if (moveable)
        {
            _followingMouse = false;
            _awaked = true;
        }
    }

    private IEnumerator EnablePhysic()
    {
        yield return new WaitForSeconds(.1f);
    }
}
