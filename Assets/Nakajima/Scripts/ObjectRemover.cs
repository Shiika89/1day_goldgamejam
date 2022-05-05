﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームプレイ範囲から出たオブジェクトを消去するクラス
/// </summary>
public class ObjectRemover : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OutsideArea")
        {
            //消去するときに何かイベントを実行する場合はここに記述
            Destroy(gameObject);
        }
    }
}
