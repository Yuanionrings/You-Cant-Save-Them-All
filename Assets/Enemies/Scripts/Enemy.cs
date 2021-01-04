using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Movement
    public float speed;
    private bool lookRight = true;
    public Transform rayAnchorPoint;
    public bool isMoving = true;

    // Animation
    private Animator anim;
    // Stun Timing
    public float stunDuration;
    public float stunTimer;
    public bool isStunned = false;

    // Player Reference
    public Player player;

    // Sound stuff
    private AudioSource eggEnemy;
    private AudioSource playerEnemy;
    private int lossTime = 5;

    void Start()
    {
        AudioSource[] sounds = GetComponents<AudioSource>();
        eggEnemy = sounds[0];
        playerEnemy = sounds[1];
        anim = GetComponent<Animator>();
        stunDuration = 1f;
        stunTimer = stunDuration;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Enemy Movement (Detects if there is still ground to move in front, if not, turn around)
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            RaycastHit2D lookAtGroundRay = Physics2D.Raycast(rayAnchorPoint.position, Vector2.down, 0.25f);
            if (lookAtGroundRay.collider == false) 
            {
                if (lookRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    lookRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    lookRight = true;
                }
            }
        } 
        else
        {
            // Stun Timer
            if (stunTimer <= 0)
            {
                stunTimer = stunDuration;
                isMoving = true;
                anim.SetBool("stunned", false);
                isStunned = false;
            } 
            else
            {
                stunTimer -= Time.deltaTime;
            }
        }

    }

    private void FixedUpdate()
    {
        anim.SetBool("eat", false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "egg(Clone)":
                // Stop moving, start stunned animation
                isMoving = false;
                anim.SetBool("stunned", true);
                isStunned = true;

                // Add Sound effect?
                eggEnemy.Play();

                // Instantiate(____, this.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);

                break;
            case "Player":
                if (player.chickensCarried < 1 && !isStunned)
                {
                    Timer.SubtractTime(lossTime);
                }
                if (player.chickensCarried > 0 && !isStunned)
                {
                    playerEnemy.Play();

                    anim.SetBool("eat", true);
                    player.chickensCarried--;
                    Timer.SubtractTime(lossTime);
                }
                break;
        }
    }
}
