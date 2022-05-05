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
        NowBullet--;

        if (NowBullet == 0)
        {
            GameEnd();
        }
    }

    static async void GameEnd()
    {
        await Task.Delay(Fire.Instance.GameEndWaitTime * 1000);

        GameManager.Instance.GameEnd();
    }
}
