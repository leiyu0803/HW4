using TMPro;
using Unity.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _pipePrefab;

    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _maxScoreText;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _newMaxScoreText;
    public static GameController Instance { get; private set; }
    public static Player Player { get; private set; }



    public static bool _isGameOver = false;
    private float _maxCooldown = 2f;
    private float _cooldown = 0f;
    private int _score = 0;
    private int _maxScore = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Player.OnPlayerDead += OnPlayerDead;
        Player.OnPlayerScore += OnPlayerScore;
        Player.OnGameStart += GameStart;
        GameStart();
    }

    private void OnPlayerScore()
    {
        _score++;
        UpdateUI();
    }

    private void OnPlayerDead()
    {
        _isGameOver = true;
        _gameOverPanel.SetActive(true);
    }
    public void GameStart() 
    {
        _isGameOver = false;
        _newMaxScoreText.SetActive(false);
        _gameOverPanel.SetActive(false);
        _score = 0;
        UpdateUI();
    }
    private void Update()
    {
        if (_isGameOver) { return; }
        _cooldown -= Time.deltaTime;

        if(_cooldown<=0f)
        {
            _cooldown = _maxCooldown;
            Instantiate(_pipePrefab, new Vector3(10f, Random.Range(0f, -4f), 0f), Quaternion.identity);
        }
    }
    private void UpdateUI()
    {
        _scoreText.text = "Score: "+ _score;
        if (_score > _maxScore) 
        { 
            _maxScore = _score;
            _maxScoreText.text = "Max Score: " + _maxScore;
            _newMaxScoreText.SetActive(true);
        }
    }
}
