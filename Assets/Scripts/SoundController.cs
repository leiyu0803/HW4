using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance { get; private set; }

    [SerializeField] AudioSource _jumpSound;
    [SerializeField] AudioSource _deadSound;
    [SerializeField] AudioSource _startSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        GameController.Player.OnPlayerJump += PlayJumpSound;
        GameController.Player.OnPlayerDead += PlayDeadSound;
        GameController.Player.OnGameStart += PlayStartSound;
        GameController.Player.OnPlayerScore += PlayStartSound;
    }

    private void PlayJumpSound()
    {
        _jumpSound.Play();
    }
    private void PlayDeadSound()
    {
        _deadSound.Play();
    }
    private void PlayStartSound()
    {
        _startSound.Play();
    }
}
