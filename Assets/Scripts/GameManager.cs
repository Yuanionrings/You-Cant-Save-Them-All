using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    public Player player;

    public GameObject chicken1, chicken2, chicken3;

    public GameObject gameEnd;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        switch (player.chickensCarried)
        {
            case 3:
                chicken1.SetActive(true);
                chicken2.SetActive(true);
                chicken3.SetActive(true);
                break;
            case 2:
                chicken1.SetActive(true);
                chicken2.SetActive(true);
                chicken3.SetActive(false);
                break;
            case 1:
                chicken1.SetActive(true);
                chicken2.SetActive(false);
                chicken3.SetActive(false);
                break;
            case 0:
                chicken1.SetActive(false);
                chicken2.SetActive(false);
                chicken3.SetActive(false);
                break;

        }

        if (Timer.getTime() <= 0)
        {
            gameEndScreen();
        }
    }

    public void gameEndScreen()
    {
        gameEnd.SetActive(true);
    }

    public void onRestartClick()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void onMenuClick()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

}
