using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    public float gravityModifier;
    bool isOnGround = true;
    public bool gameOver = false;

    Animator animator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();       
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround && gameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.clip = jumpSound;
            playerAudio.Play();
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //rb.useGravity = true;
            //rb.AddForce(new Vector3(50, 50, 0), ForceMode.Impulse);
            //rb.freezeRotation = false;

            
            collision.rigidbody.AddForce(new Vector3(15, 15, 0), ForceMode.Impulse);

            gameOver = true;

            animator.SetInteger("DeathType_int", 1);
            animator.SetBool("Death_b", true);
            

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.clip = crashSound;
            playerAudio.Play();
        }
        
    }
}
