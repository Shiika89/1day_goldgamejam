using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveSpeed : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] Vector3 dir;
    [SerializeField] float _minimumSpeed, _maxSpeed;

    void Start()
    {
        float n = Random.Range(_minimumSpeed, _maxSpeed);
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = dir.normalized * n;
    }
}
