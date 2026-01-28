using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void PlayerDeadDelegate();
    public event PlayerDeadDelegate OnPlayerDead;
    public delegate void PlayerScoreDelegate();
    public event PlayerScoreDelegate OnPlayerScore;
    public delegate void PlayerJumpDelegate();
    public event PlayerJumpDelegate OnPlayerJump;
    public delegate void GameStartDelegate();
    public event GameStartDelegate OnGameStart;

    private void Start()
    {
        GameStart();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayerJump?.Invoke();
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 4f;
        }
    }
    public void GameStart()
    {
        transform.position = new Vector3(-1f, 0f, 0f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        OnGameStart?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (GameController._isGameOver) { return; }
        if (collider.gameObject.CompareTag("Pipe"))
        {
            OnPlayerDead?.Invoke();
        }
        if (collider.gameObject.CompareTag("Score"))
        {
            OnPlayerScore?.Invoke();
        }
    }
}
