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
    private void Start()
    {
        FadeController.StartFadeIn();
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
    public void ReStart()
    {
        GameLoop.GameInit();
    }
}
