using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Range(0f, 15f)]
    [SerializeField] private float _gameTimeScale = 1f;
    [SerializeField] private Slider _sliderTimeScale;
    [SerializeField] private UnityEvent OnGameOver;
        
    private static GameManager _instance;
    private bool _gameOver;
    private bool _win;
    private int _enemyCount = 0;
    private GameState _currentGameState;

    public int EnemyCount { get => _enemyCount; set => _enemyCount = value; }
    public static GameManager Instance => _instance;
    public bool GameOver 
    { 
        get => _gameOver;
        set 
        {
            _gameOver = value;
            CurrentGameState = GameState.GameOver;
            OnGameOver?.Invoke();
        }
    }
    public bool Win { get => _win; set => _win = value; }
    public float GameTimeScale { get => _gameTimeScale; set => _gameTimeScale = value; }
    public enum GameState
    {
        Playing,
        GameOver,
    }
    public GameState CurrentGameState { get => _currentGameState; set => _currentGameState = value; }

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        Time.timeScale = _gameTimeScale;
    }
    
}
