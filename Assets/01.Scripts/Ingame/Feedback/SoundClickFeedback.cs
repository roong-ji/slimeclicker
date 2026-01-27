using UnityEngine;

public class SoundClickFeedback : MonoBehaviour, IClickFeedback
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    
    public void Play(ClickInfo info)
    {
        if (info.Type == EClickType.Auto) return;
        
        _audio.pitch = Random.Range(_minPitch, _maxPitch);
        _audio.Play();
    }
}
