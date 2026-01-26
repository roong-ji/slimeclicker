using DG.Tweening;
using UnityEngine;

public class ScaleTweeningFeedback : MonoBehaviour, IFeedback
{
    [Header("Settings")]
    [SerializeField] private Vector3 _punchAmount = new Vector3(0.3f, -0.3f, 0);
    [SerializeField] private int _vibrato = 10;
    [SerializeField] private float _elasticity = 1f;
    [SerializeField] private float _duration = 0.6f;

    public void Play(ClickInfo info)
    {
        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        
        transform.DOPunchScale(_punchAmount, _duration, _vibrato, _elasticity);
        
        float randomZ = Random.Range(-10f, 10f);
        transform.DOPunchRotation(new Vector3(0, 0, randomZ), _duration, _vibrato, _elasticity);
    }
}
