using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Range(0f, 15f)]
    [SerializeField] private float _gameTimeScale = 1f;
    [SerializeField] private UnityEvent OnGameOver;
    [SerializeField] private Slider _sliderTimeScale;

    private static GameManager _instance;
    private bool _gameOver;
    private bool _win;
    private int _enemyCount = 0;

    public int EnemyCount { get => _enemyCount; set => _enemyCount = value; }
    public static GameManager Instance => _instance;

    public bool GameOver 
    { 
        get => _gameOver;
        set 
        {
            OnGameOver?.Invoke();
            _gameOver = value; 
        }
    }
    public bool Win { get => _win; set => _win = value; }
    public float GameTimeScale { get => _gameTimeScale; set => _gameTimeScale = value; }

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        Time.timeScale = _gameTimeScale;
    }
    
}
