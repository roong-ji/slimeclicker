using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeDataTableSO", menuName = "Scriptable Objects/UpgradeDataTableSO")]
public class UpgradeDataTableSO : ScriptableObject
{
    [SerializeField] private SerializableDictionary<EStatType, UpgradeData> _datas;
    public IReadOnlyDictionary<EStatType, UpgradeData> Datas => _datas;
    
    public UpgradeData GetData(EStatType statType)
    {
        return _datas.GetValueOrDefault(statType);
    }
}