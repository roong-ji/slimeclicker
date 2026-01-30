using UnityEngine;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _popupLogin;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _popupLogin.SetActive(true);
    }

    public void ClosePopupLogin()
    {
        _popupLogin.SetActive(false);
    }
}
