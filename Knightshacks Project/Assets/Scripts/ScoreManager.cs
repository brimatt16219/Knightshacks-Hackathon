using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text coinText;
    public Text healthText;
    int score = 0;
    public float health = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    
    public void ChangeHealth(float damage)
    {
        health -= damage;
        healthText.text = health.ToString();
    }
    

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        coinText.text = score.ToString();
    }
}

