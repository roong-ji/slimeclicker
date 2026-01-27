using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipFloater : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Show(_text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }
}
