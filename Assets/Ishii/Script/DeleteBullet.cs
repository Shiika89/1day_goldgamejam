using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    [SerializeField] float m_desPos;

    void Update()
    {
        // 弾が一定以下まで落ちたら消える
        if (this.transform.position.y < m_desPos)
        {
            Destroy(gameObject);
        }
    }
}
