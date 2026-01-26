using System;
using DG.Tweening;
using UnityEngine;

public class ScaleTweeningFeedback : MonoBehaviour
{
    [SerializeField] private ClickTarget _owner;
    [SerializeField] private float _endvalue;
    [SerializeField] private float _duration;
    
#if UNITY_EDITOR
    private void Reset()
    {
        _owner = GetComponent<ClickTarget>();
    }
#endif

    private void Awake()
    {
        _owner.OnClicked += PlayTween;
    }

    private void OnDestroy()
    {
        _owner.OnClicked -= PlayTween;
    }

    private void PlayTween()
    {
        _owner.transform.DOKill();
        _owner.transform.DOScale(_endvalue, _duration).OnComplete(() => 
        {
            _owner.transform.localScale = Vector3.one;
        });
    }
}
