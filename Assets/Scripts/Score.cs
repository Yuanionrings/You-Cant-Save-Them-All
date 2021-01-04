using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int currentScore;
    private Text score;

    void Start()
    {

        score = GetComponent<Text>();
        currentScore = 0;
    }

    void Update()
    {
        score.text = "Chicks Saved: " + currentScore;
    }
}
