using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("Setup")]
    public AudioClip backgroundMusic;
    [Range(0f, 1f)] public float volume = 0.5f;

    private AudioSource _source;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _source = gameObject.AddComponent<AudioSource>();
            _source.clip = backgroundMusic;
            _source.loop = true;
            _source.volume = volume;
            _source.playOnAwake = false;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        if (_source != null && backgroundMusic != null && !_source.isPlaying)
        {
            _source.Play();
        }
    }

    public void SetMuted(bool muted)
    {
        if (_source != null)
        {
            _source.mute = muted;
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (_source != null)
        {
            _source.volume = volume;
        }
    }
}
