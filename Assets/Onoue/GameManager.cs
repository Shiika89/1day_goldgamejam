using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get;private set; }
    void Awake()
    {
        Instance = this;
    }
    public void GameStart()
    {
        //ボタンを押した時にゲームが始まる
        GameLoop.GameStart();
    }
    public void GameEnd()
    {
        GameLoop.GameEnd();
    }
}
