using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] Text scoreText;
    void Start()
    {
        score = 0;
    }
    
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
