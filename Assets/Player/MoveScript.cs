using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioClip jumpSoundGround;
    [SerializeField] private AudioClip jumpSoundAir;
    private AudioSource playerAudio;
    [SerializeField] private bool isOnGround = false;
    private bool canSecondJump;
    private Rigidbody2D _playerRB2D;
    [SerializeField] private GameObject rightBodySide;
    [SerializeField] private GameObject leftBodySide;
    private BodyCheckCollision rightSide;
    private BodyCheckCollision leftSide;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        _playerRB2D = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        rightSide = rightBodySide.GetComponent<BodyCheckCollision>();
        leftSide = leftBodySide.GetComponent<BodyCheckCollision>();
    }

    // Update is called once per frame

    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal") * speed, _playerRB2D.velocity.y);
        // player moving
      //  Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") > 0 && !rightSide.IsColliding())
        {
            _playerRB2D.velocity = move;
        }
        if (Input.GetAxis("Horizontal") < 0 && !leftSide.IsColliding())
        {
            _playerRB2D.velocity = move;
        }
        // jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Jump()
    {
        
        if (isOnGround)
        {
            _playerRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAudio.PlayOneShot(jumpSoundGround);
            isOnGround = false;
        }
        else if (canSecondJump)
        {
            move = new Vector2(_playerRB2D.velocity.x, 0);
            _playerRB2D.velocity = move;
            _playerRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAudio.PlayOneShot(jumpSoundAir);
            canSecondJump = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            canSecondJump = true;
        }
    }
}
