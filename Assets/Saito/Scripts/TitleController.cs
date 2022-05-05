using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    Button m_startButton = default;

    [SerializeField]
    Text m_startText = default;

    void Start()
    {
        SoundManager.PlayBGM(BGMType.Title);
        m_startButton.onClick.AddListener(() => 
        {
            //m_startText.text = "";
            SoundManager.PlaySE(SEType.Start);
        }); 
    }

    public void ChangeMainScene()
    {
        SceneChange.LoadGame("MainScene");
    }
}
