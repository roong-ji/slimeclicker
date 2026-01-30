using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipFloater : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EStatType _type;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Show(_type);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }
}
