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

    [SerializeField] Text m_numBullets;

    private void OnEnable()
    {
        GameLoop.OnGameInit += () => OnGameInitUI();
        GameLoop.OnGameEnd += () => OnResultUI();
        Score.OnUpdateScore += () => OnUpdateScore();
    }

    private void OnDisable()
    {
        GameLoop.OnGameInit -= () => OnGameInitUI();
        GameLoop.OnGameEnd -= () => OnResultUI();
        Score.OnUpdateScore -= () => OnUpdateScore();
    }

    /// <summary>
    /// スコアが加算するたびに呼ばれる
    /// </summary>
    public void OnUpdateScore()
    {
        m_nowScoreText.text = $"SCORE ; {Score.TotalScore}";　// 現在のスコアを表示
        
    }

    /// <summary>
    /// ゲーム開始時やリスタート時に呼ばれる
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
        m_totalScoreText.text = $"SCORE ; {Score.TotalScore}";　// リザルトスコアを表示
        m_restratPanel.SetActive(true); // リザルトパネルをアクティブ化
    }
}
