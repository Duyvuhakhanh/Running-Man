using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    public bool doubleSpeed = false;
    public bool doubleJumpUsed = false;
    public float doubleJumpForce = 5;
    public float jumpForce = 10.0f;
    public float gravityModify;
    public bool isGroundCheck = true;
    public bool gameOver;
    public int count;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModify;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpMechanic();
        DashModeOn();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundCheck = true;
            if (gameOver == false)
            {
                dirtParticle.Play();
            }
                
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
    // Makde player jump 
    void JumpMechanic()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGroundCheck && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            doubleJumpUsed = false;
            isGroundCheck = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJumpUsed && !isGroundCheck)
        {
            playerAnim.Play("Running_Jump", 3);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            doubleJumpUsed = true;
        }
    }
    // On Dash mode
    void DashModeOn()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGroundCheck && !gameOver)
        {
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
            doubleSpeed = true;
        }
        else if (doubleSpeed)
        {
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
            doubleSpeed = false;
        }
    }
}
