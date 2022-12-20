using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
  
   public TextMeshProUGUI scoreText;
   private int _score = 0;

    private void Start()
    {


    }

    private void Update()
    {
    }

    public void IncreaseScore(int index)
    {

        _score += index;
        scoreText.text = _score.ToString();
       
    }
}
