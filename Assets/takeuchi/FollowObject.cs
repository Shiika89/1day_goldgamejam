using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    Transform _followTarget = default;
    [SerializeField]
    float _followSpeed = 1f;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _followTarget.position, _followSpeed * Time.deltaTime);
    }
}
