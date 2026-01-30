using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LocalUpgradeRepository : IRepository<Dictionary<EStatType, Upgrade>>
{
    private UpgradeDataTableSO _dataSO;

    private readonly string _saveFilePath = Path.Combine(Application.persistentDataPath, SaveFileName);
    private const string SaveFileName = "Upgrade.dat";
    
    public LocalUpgradeRepository(UpgradeDataTableSO dataSO)
    {
        _dataSO = dataSO;
    }
    
    public void Save(Dictionary<EStatType, Upgrade> data)
    {
        var saveData = new UpgradeSaveData();
        foreach (var item in data)
        {
            var saveItem = new UpgradeInfo(item.Key, item.Value.Level);
            saveData.Add(saveItem);
        }
        FileIO.Save(saveData, _saveFilePath);
    }

    public Dictionary<EStatType, Upgrade> Load()
    {
        var data = new Dictionary<EStatType, Upgrade>();
        var saveData = new UpgradeSaveData();
        FileIO.Load(saveData, _saveFilePath);

        foreach (var item in saveData.SaveData)
        {
            var info = _dataSO.GetData(item.Type);
            var upgrade = new Upgrade(info, item.Type, item.Level);
            data.Add(item.Type, upgrade);
        }
        
        foreach (var info in _dataSO.Datas)
        {
            if (data.ContainsKey(info.Key)) continue;
            var upgrade = new Upgrade(info.Value, info.Key);
            data.Add(info.Key, upgrade);
        }
        
        return data;
    }
}

[System.Serializable]
public class UpgradeSaveData
{ 
    [SerializeField] private List<UpgradeInfo> _saveData;
    public List<UpgradeInfo> SaveData => _saveData;
    
    public UpgradeSaveData(List<UpgradeInfo> saveData = null)
    {
        _saveData = saveData ?? new ();
    }

    public void Add(UpgradeInfo info)
    {
        _saveData.Add(info);
    }
}

[System.Serializable]
public struct UpgradeInfo
{
    public EStatType Type;
    public int Level;
    
    public UpgradeInfo(EStatType type, int level)
    {
        Type = type;
        Level = level;
    }
}
