using UnityEngine;

public class SoundFeedback : MonoBehaviour, IFeedback
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    
    public void Play()
    {
        _audio.pitch = Random.Range(_minPitch, _maxPitch);
        _audio.Play();
    }
}
