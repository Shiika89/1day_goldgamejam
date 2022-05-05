using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Score 
{
    static int s_totalScore;
    public static int TotalScore 
    {
        get => s_totalScore;
        private set 
        {
            s_totalScore = value;
            OnUpdateScore?.Invoke();
        } 
    }
    public static event Action OnUpdateScore;
    static public void AddScore(int score)
    {
        TotalScore += score;
    }
    static public void Init()
    {
        TotalScore = 0;
    }
}
