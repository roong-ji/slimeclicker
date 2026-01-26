using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ColorFlashFeedback : MonoBehaviour
{
    [SerializeField] private ClickTarget _owner;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _flashColor;
    [SerializeField] private float _interval;
    
    private Coroutine _flashRoutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new(_interval);
        _owner.OnClicked += Play;
    }

    private void OnDestroy()
    {
        _owner.OnClicked -= Play;
    }
    
    private void Play()
    {
        if (_flashRoutine != null)
        {
            StopCoroutine(_flashRoutine);
            _flashRoutine = null;
        }
        
        _flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        _spriteRenderer.color = _flashColor;

        yield return _wait;
        
        _spriteRenderer.color = Color.white;
    }
}
