using UnityEngine;

[CreateAssetMenu(fileName = "TooltipDataTableSO", menuName = "Scriptable Objects/TooltipDataTableSO")]
public class TooltipDataTableSO : ScriptableObject
{
    [SerializeField] private SerializableDictionary<EStatType, string> _statDict;

    public string GetTooltip(EStatType statType)
    {
        return _statDict.GetValueOrDefault(statType);
    }
}
