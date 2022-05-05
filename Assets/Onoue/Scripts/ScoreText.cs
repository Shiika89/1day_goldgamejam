using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
    }
    public void SetScore(int score)
    {
        _text.text = score.ToString();
    }
}
