using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class NumberOfBullets
{
    static public int NowBullet
    {
        get => Fire.Instance.NowBullet;
        set
        {
            Fire.Instance.NowBullet = value;
            OnUpdetaBullet?.Invoke();
        }
    }

    static public event Action OnUpdetaBullet;

    static public void DecreaseBullet()
    {
        NowBullet--; // 弾数を減らす

        if (NowBullet == 0)
        {
            GameEnd(); // 最後の弾を撃ったら終了
        }
    }

    static async void GameEnd()
    {
        // 最後の弾を撃ってから時間を空ける
        await Task.Delay(Fire.Instance.GameEndWaitTime * 1000);

        GameManager.Instance.GameEnd();
    }
}
