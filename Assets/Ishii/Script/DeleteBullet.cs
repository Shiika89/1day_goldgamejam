using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    [SerializeField] float m_desPos;

    void Update()
    {
        if (this.transform.position.y < m_desPos)
        {
            Destroy(gameObject);
        }
    }
}
