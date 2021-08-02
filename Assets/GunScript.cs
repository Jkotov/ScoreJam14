using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject reyStart;
    private Camera _camera;
    private Vector3 _mousePos;
    private SpriteRenderer _renderer;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _renderer.enabled = true;
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = reyStart.transform.position.z;
            transform.localScale = new Vector3( (float)Math.Sqrt(
                Math.Pow(reyStart.transform.position.x - _mousePos.x, 2) +
                Math.Pow(reyStart.transform.position.y - _mousePos.y, 2)), 1, 1);
            transform.position = new Vector3((reyStart.transform.position.x + _mousePos.x) / 2,
                (reyStart.transform.position.y + _mousePos.y) / 2, 1);
            float sign = Math.Sign(_mousePos.y - transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0,
                Vector3.Angle(sign * (_mousePos - reyStart.transform.position), Vector3.right));
        }
        else
        {
            _renderer.enabled = false;
        }
    }

}
