using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private LayerMask _clickLayer;
    Camera _mainCamera;
    
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        Vector2 mousePosition = Input.mousePosition;
        Click(mousePosition);
    }

    private void Click(Vector2 mousePosition)
    {
        Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, 0f, _clickLayer);

        if (!hit) return;

        if (!hit.collider.TryGetComponent(out IClickable clickTarget)) return;
        clickTarget.OnClick();
    }
}
