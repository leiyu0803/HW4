using UnityEngine;

public class Pipe : MonoBehaviour
{
	private float _speed = 2f;
	private void Start()
	{
		GameController.Player.OnPlayerDead += OnPlayerDead;
		GameController.Player.OnGameStart += destroy;
    }
    private void Update()
	{
		transform.position += Vector3.left * _speed * Time.deltaTime;
		if (transform.position.x < -10f)
		{
			destroy();
        }
    }
	private void OnPlayerDead()
	{ 
		_speed = 0f;
    }
	private void destroy()
	{
        GameController.Player.OnPlayerDead -= OnPlayerDead;
        GameController.Player.OnGameStart -= destroy;
        Destroy(gameObject);

    }
}
