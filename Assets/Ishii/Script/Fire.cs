using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾を飛ばすクラス
/// </summary>
public class Fire : MonoBehaviour
{
    static public Fire Instance;

    [Tooltip("弾を出したい位置のオブジェクト")]
    [SerializeField] GameObject m_muzzle;

    [Tooltip("発射する弾のオブジェクト")]
    [SerializeField] GameObject m_bullet;

    [Tooltip("弾のスピード")]
    [SerializeField] float m_bulletSpeed;

    [Tooltip("次の弾が撃てるまでのインターバル")]
    [SerializeField] float m_interval;
    float _timer;

    [Tooltip("弾の最大弾数")]
    [SerializeField] int m_maxBullet;
    public int MaxBullet { get => m_maxBullet; }

    // 弾の現在弾数
    public int NowBullet { get; set; }

    [Tooltip("最後の弾を撃ってからリザルト画面を出すまでの時間")]
    [SerializeField] int m_gameEndWaitTime;
    public int GameEndWaitTime { get => m_gameEndWaitTime; }

    bool _IsStart; // ゲーム中か判定するフラグ


    void Awake()
    {
        Instance = this;
        NowBullet = m_maxBullet; // 現在弾数を最大弾数と同じに
    }

    private void OnEnable()
    {
        GameLoop.OnGameStart += GameStart;
        GameLoop.OnGameEnd += GameEnd;
        NumberOfBullets.OnUpdetaBullet += BulletCheck;
    }

    private void OnDisable()
    {
        GameLoop.OnGameStart -= GameStart;
        GameLoop.OnGameEnd -= GameEnd;
        NumberOfBullets.OnUpdetaBullet-= BulletCheck;
    }

    void Update()
    {
        if (_IsStart == false) return;

        _timer += Time.deltaTime;

        if (_timer > m_interval && NowBullet != 0) // 一定時間ごとに撃てる
        {
            // 左クリックで発射
            if (Input.GetMouseButtonDown(0))
            {
                BulletShot();
                NumberOfBullets.DecreaseBullet(); // 弾数を減らす
                _timer = 0;
            }
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

        EffectManager.Instance.PlayEffect(EffectType.Shot, m_muzzle.transform.position);

        SoundManager.PlaySE(SEType.Shot);
    }

    void GameStart()
    {
        _IsStart = true;
    }

    void GameEnd()
    {
        _IsStart = false;
        NowBullet = m_maxBullet; // リスタート時は弾数リセット
    }

    IEnumerator OutOfBullet()
    {
        yield return new WaitForSeconds(m_gameEndWaitTime);

        GameManager.Instance.GameEnd();
    }

    public void BulletCheck()
    {
        if (NowBullet == 0)
        {
            StartCoroutine(OutOfBullet());
        }
    }
}
