using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    void Start()
    {
        SoundManager.PlayBGM(BGMType.Title);
    }

    public void ChangeMainScene()
    {
        SceneChange.LoadGame("MainScene");
    }
}
