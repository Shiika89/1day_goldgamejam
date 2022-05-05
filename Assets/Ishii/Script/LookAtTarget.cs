using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大砲の向きを照準の位置に向かせるクラス
/// </summary>
public class LookAtTarget : MonoBehaviour
{
    [Tooltip("向かせる大砲自身")]
    [SerializeField] Transform m_myself;

    [Tooltip("向かせたい相手")]
    [SerializeField] Transform m_target;

    void Update()
    {
        m_myself.LookAt(m_target);
    }
}
