﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TargetController : MonoBehaviour
{
    [Tooltip("当てた際に加算するスコア")]
    [SerializeField]
    int m_scoreValue = 100;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannon") //大砲がヒットした場合
        {
            //スコア加算の処理
            Score.AddScore(m_scoreValue);
            //エフェクト生成

            //自身を消去
            Destroy(gameObject);
        }
    }
}