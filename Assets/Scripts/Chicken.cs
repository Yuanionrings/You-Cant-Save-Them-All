using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Player player;
    private AudioSource pickup;

    private bool disabled;

    void Start()
    {
        disabled = false;
        pickup = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.chickensCarried < 3 && !disabled)
        {
            pickup.Play();

            player.chickensCarried++;

            // Hide game object to let sound play before destroying it
            StartCoroutine(destroyer(5));
        }
    }

    private void disable()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        disabled = true;
    }

    IEnumerator destroyer(int seconds)
    {
        disable();
        yield return new WaitForSeconds(seconds);
        this.gameObject.SetActive(false);
        disabled = false;
    }
}
