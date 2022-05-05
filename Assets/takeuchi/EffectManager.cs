using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    Explosion,
    Shot,
    CoinBurst
}
/// <summary>
/// エフェクトを再生する
/// </summary>
public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    [SerializeField]
    GameObject[] m_effectPrefabs;
    [SerializeField]
    float[] m_shakes = { 0.5f, 0.2f, 0.5f };
    private void Awake()
    {
        Instance = this;
    }
    public void PlayEffect(EffectType type,Vector3 pos)
    {
        ShakeController.PlayShake(m_shakes[(int)type]);
        Instantiate(m_effectPrefabs[(int)type]).transform.position = pos;
    }
}
