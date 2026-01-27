using Lean.Pool;
using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    public static SoundSpawner Instance { get; private set; }

    [SerializeField] private LeanGameObjectPool _pool;
    [SerializeField] private float _minPitch = 0.9f;
    [SerializeField] private float _maxPitch = 1.1f;
    
    private void Awake()
    {
        Instance = this;
    }

    public void PlayClip(AudioClip clip, bool isRandomPitch = false)
    {
        GameObject soundObject = _pool.Spawn(transform);
        if (!soundObject.TryGetComponent(out AudioSource audio)) return;
        if (isRandomPitch)
        {
            audio.pitch = Random.Range(_minPitch, _maxPitch);
        }
        audio.PlayOneShot(clip);
        LeanPool.Despawn(soundObject, clip.length);
    }
}
