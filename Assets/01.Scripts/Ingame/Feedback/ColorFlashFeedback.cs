using System.Collections;
using UnityEngine;

public class ColorFlashFeedback : MonoBehaviour, IFeedback
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _flashColor;
    [SerializeField] private float _interval;
    
    private Coroutine _flashRoutine;
    private WaitForSeconds _wait;

#if UNITY_EDITOR
    private void Reset()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
#endif
    
    private void Awake()
    {
        _wait = new(_interval);
    }
    
    public void Play()
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
