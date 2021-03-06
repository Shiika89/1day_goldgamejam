using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Tooltip("ゲームを開始するボタン")]
    [SerializeField] GameObject m_startButton;

    [Tooltip("ゲームが終了して再度プレイするボタン")]
    [SerializeField] GameObject m_restratPanel;

    [Tooltip("ゲームが終わった時に表示するスコア")]
    [SerializeField] Text m_totalScoreText;

    [Tooltip("ゲーム中に表示するスコア")]
    [SerializeField] Text m_nowScoreText;

    [Tooltip("弾の弾数表示")]
    [SerializeField] Text m_numBullets;

    private void OnEnable()
    {
        GameLoop.OnGameStart += () => OnGameStart();
        GameLoop.OnGameInit += () => OnGameInitUI();
        GameLoop.OnGameEnd += () => OnResultUI();
        Score.OnUpdateScore += () => OnUpdateScore();
        NumberOfBullets.OnUpdetaBullet += () => OnUpdateBullet();
    }

    private void OnDisable()
    {
        GameLoop.OnGameStart -= () => OnGameStart();
        GameLoop.OnGameInit -= () => OnGameInitUI();
        GameLoop.OnGameEnd -= () => OnResultUI();
        Score.OnUpdateScore -= () => OnUpdateScore();
        NumberOfBullets.OnUpdetaBullet -= () => OnUpdateBullet();
    }

    /// <summary>
    /// スコアが加算するたびに呼ばれる
    /// </summary>
    public void OnUpdateScore()
    {
        m_nowScoreText.text = $"{Score.TotalScore}";　// 現在のスコアを表示
        
    }

    /// <summary>
    /// 弾を撃つたびに呼ばれる
    /// </summary>
    public void OnUpdateBullet()
    {
        m_numBullets.text = $"{NumberOfBullets.NowBullet} / {Fire.Instance.MaxBullet}";
    }

    /// <summary>
    /// リスタート時に呼ばれる
    /// </summary>
    public void OnGameInitUI()
    {
        m_startButton.SetActive(true); // スタートボタンを表示
        m_restratPanel.SetActive(false); // リスタートパネルを非表示
    }

    /// <summary>
    /// ゲームが終了すると呼ばれる
    /// </summary>
    public void OnResultUI()
    {
        m_totalScoreText.text = $"スコア : {Score.TotalScore}";　// リザルトスコアを表示
        m_restratPanel.SetActive(true); // リザルトパネルをアクティブ化
    }

    /// <summary>
    /// ゲームが開始すると呼ばれる
    /// </summary>
    public void OnGameStart()
    {
        m_startButton.SetActive(false); // スタートボタンを非表示
        m_numBullets.text = $"{NumberOfBullets.NowBullet} / {Fire.Instance.MaxBullet}";
    }
}
