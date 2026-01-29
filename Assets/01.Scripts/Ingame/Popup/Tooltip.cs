using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    [SerializeField] private TooltipDataTableSO _tooltipSO;
    
    public static Tooltip Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        transform.localScale = Vector3.one;
    }

    public void Show(EStatType statType)
    {
        var text = _tooltipSO.GetTooltip(statType);
        _textUI.SetText(text);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
