using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float increment = 1f;
    
    private float score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (FindObjectOfType<Player>().isAlive)
        {
            score += increment * Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(score).ToString(); 
        }
    }
}
