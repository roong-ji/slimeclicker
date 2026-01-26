using DG.Tweening;
using UnityEngine;

public class ScaleTweeningFeedback : MonoBehaviour, IFeedback
{
    [SerializeField] private Transform _owner;
    [SerializeField] private float _endvalue;
    [SerializeField] private float _duration;
    
#if UNITY_EDITOR
    private void Reset()
    {
        _owner = GetComponent<Transform>();
    }
#endif

    public void Play(ClickInfo info)
    {
        _owner.transform.DOKill();
        _owner.transform.DOScale(_endvalue, _duration).OnComplete(() => 
        {
            _owner.transform.localScale = Vector3.one;
        });
    }
}
