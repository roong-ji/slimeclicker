using DG.Tweening;
using UnityEngine;

public class SoundFeedback : MonoBehaviour, IClickFeedback, ISpawnFeedback, IDespawnFeedback
{
    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _spawnClip;
    [SerializeField] private AudioClip _despawnClip;
    
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
        SoundSpawner.Instance.PlayClip(clip, true);
    }
}
