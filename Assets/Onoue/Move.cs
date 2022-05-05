using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] Vector3 dir;
    [SerializeField] float speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = dir.normalized * speed;
    }
}
