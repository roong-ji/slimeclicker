using DG.Tweening;
using UnityEngine;

public class SoundFeedback : MonoBehaviour, IClickFeedback, ISpawnFeedback, IDespawnFeedback
{
    [SerializeField] private AudioSource _audio;

    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _spawnClip;
    [SerializeField] private AudioClip _despawnClip;
    
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    
    public void Play(ClickInfo info)
    {
        if (info.Type == EClickType.Auto) return;
        PlaySound(_clickClip);
    }

    public void OnSpawn()
    {
        PlaySound(_spawnClip);
    }
    
    public void OnDespawn()
    {
        PlaySound(_despawnClip);
    }

    private void PlaySound(AudioClip clip)
    {
        _audio.pitch = Random.Range(_minPitch, _maxPitch);
        _audio.PlayOneShot(clip);
    }
}
