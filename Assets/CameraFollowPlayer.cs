using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 cameraOffset;
    private Vector3 _pos;
    void Update()
    {
        if (player)
        {
            _pos = player.transform.position + cameraOffset;
            _pos.z = -25.5f;
            transform.position = _pos;
        }
    }
}
