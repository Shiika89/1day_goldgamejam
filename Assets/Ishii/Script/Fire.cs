using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾を飛ばすクラス
/// </summary>
public class Fire : MonoBehaviour
{
    [Tooltip("弾を出したい位置のオブジェクト")]
    [SerializeField] GameObject m_muzzle;

    [Tooltip("発射する弾のオブジェクト")]
    [SerializeField] GameObject m_bullet;

    [Tooltip("弾のスピード")]
    [SerializeField] float m_bulletSpeed;


    void Update()
    {
        // 左クリックで発射
        if (Input.GetMouseButtonDown(0))
        {
            BulletShot();
        }
    }

    private void BulletShot()
    {
        // 弾を発射する場所を取得
        Vector3 bulletPosition = m_muzzle.transform.position;

        // 上で取得した場所に、"m_bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(m_bullet, bulletPosition, transform.rotation);

        // 出現させた弾のforward(z軸方向)
        Vector3 dir = newBall.transform.forward;

        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(dir * m_bulletSpeed, ForceMode.Impulse);
    }
}
