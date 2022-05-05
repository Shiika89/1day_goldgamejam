using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score 
{
    static int s_totalScore;
    public static int TotalScore { get => s_totalScore; private set { } }
    static public void AddScore(int score)
    {
        s_totalScore += score;
    }
    static public void Init()
    {
        s_totalScore = 0;
    }
}
