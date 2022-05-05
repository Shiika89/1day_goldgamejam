using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TargetController : MonoBehaviour
{
    [Tooltip("当てた際に加算するスコア")]
    [SerializeField]
    int m_scoreValue = 100;
    [SerializeField]
    ScoreText _scoreText;

    bool _isHit = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannon") //大砲がヒットした場合
        {
            //エフェクト生成
            EffectManager.Instance.PlayEffect(EffectType.Explosion, transform.position);
            EffectManager.Instance.PlayEffect(EffectType.CoinBurst, transform.position);
            SoundManager.PlaySE(SEType.Hit);
            if (!_isHit)
            {
                //スコア加算の処理
                Score.AddScore(m_scoreValue);
                var text = Instantiate(_scoreText);
                text.SetScore(m_scoreValue);
                text.transform.position = transform.position;
                _isHit = true;
            }
            //自身を消去
            Destroy(gameObject);
        }
    }
}
