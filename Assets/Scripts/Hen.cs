using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Player player;
    private int extraTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        extraTime = 2;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.currentScore += player.chickensCarried;
            Timer.AddTime(extraTime * player.chickensCarried);
            player.chickensCarried = 0;
        }
    }
}
