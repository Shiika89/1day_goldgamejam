using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] float _time = 2;
    void Start()
    {
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }
    public void SetScore(int score)
    {
        _text.text = score.ToString();
    }
}
