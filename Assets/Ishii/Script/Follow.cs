using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 砲弾を撃つため照準をマウスに追従させるクラス
/// </summary>
public class Follow : MonoBehaviour
{
    Vector3 _mouse;
    Vector3 _target;

    void Update()
    {
        // マウスのpositionにtargetが追従する、zだけは固定
        _mouse = Input.mousePosition;
        _target = Camera.main.ScreenToWorldPoint(new Vector3(_mouse.x, _mouse.y, 10));
        this.transform.position = _target;
    }
}
