using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject timer;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("End"))
        {
            Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DangerObject"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void Win()
    {
        timer.GetComponent<adfa>().time = Time.timeSinceLevelLoad;
        SceneManager.LoadScene("WinScene");
    }
}
