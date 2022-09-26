using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody player;
    public float jumpForce = 15;
    public float gravityModifier = 2;
    public bool isOnGround = true;
    public bool IsGameOver;
    private Animator animator;
    public ParticleSystem explosionparticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
        animator = GameObject.Find("Player").GetComponent<Animator>();
        AudioSource = GameObject.Find("Player").GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !IsGameOver)
        {
            player.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            AudioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!IsGameOver)
            {
                dirtParticle.Play();
            }
            isOnGround = true;

        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            IsGameOver = true;
            animator.SetBool("Death_b",true);
            animator.SetInteger("DeathType_int", 1);
            explosionparticle.Play();
            dirtParticle.Stop();
            AudioSource.PlayOneShot(crashSound, 1.0f);
        }
    }
}
