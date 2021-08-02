using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReyMove : MonoBehaviour
{
    [SerializeField] private float reySpeed;
    // Update is called once per frame
    void Update()
    {
        transform.position += reySpeed * Time.deltaTime * Vector3.right;
    }
}
