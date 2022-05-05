using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _popTime;
    [SerializeField] int _maxRandNum = 0;
    float _randNum;
    float _currnetTime = 0;
    bool _inGame = false;
    private void OnEnable()
    {
        GameLoop.OnGameStart += () => SpawnStart();
        GameLoop.OnGameEnd += () => SpawnEnd();
    }
    private void OnDisable()
    {
        GameLoop.OnGameStart -= () => SpawnStart();
        GameLoop.OnGameEnd -= () => SpawnEnd();
    }
    private void Update()
    {
        if (!_inGame) return;
        _currnetTime += Time.deltaTime;

        if (_currnetTime > _popTime + _randNum) Spawn();
    }
    public void Spawn()
    {
        _currnetTime = 0;

        int randPoint = Random.Range(0, _spawnPoints.Length);
        Instantiate(_enemyPrefab, _spawnPoints[randPoint].transform.position, Quaternion.identity);
    }
    public void SpawnStart()
    {
        _currnetTime = 0;
        _randNum = Random.Range(0, _maxRandNum);
        _inGame = true;
    }
    public void SpawnEnd()
    {
        _inGame = false;
    }
}
