using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTorque : MonoBehaviour
{
    [SerializeField]
    private float m_torque = 2f;
    Rigidbody m_rb = default;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.AddTorque(Vector3.up * Random.Range(-m_torque, m_torque),ForceMode.Impulse);
    }
}
