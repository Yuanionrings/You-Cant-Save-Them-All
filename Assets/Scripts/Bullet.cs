using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    //public int damage = 40;
    private Rigidbody2D rb;
    private int bounceCount = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        rb.velocity = transform.right * speed / 2;
        bounceCount--;
        if (bounceCount < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
