using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private Text finalScore;
    void Start()
    {
        finalScore = GetComponent<Text>();
    }

    void Update()
    {
        finalScore.text = "You Saved: " + Score.currentScore + " chicks";
    }
}
