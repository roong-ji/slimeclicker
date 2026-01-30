using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LocalUpgradeRepository : IRepository<UpgradeSaveData>
{
    private readonly string _saveFilePath = Path.Combine(Application.persistentDataPath, SaveFileName);
    private const string SaveFileName = "Upgrade.dat";
    
    public void Save(UpgradeSaveData data)
    {
        FileIO.Save(data, _saveFilePath);
    }

    public UpgradeSaveData Load()
    {
        var data = new UpgradeSaveData();
        FileIO.Load(data, _saveFilePath);
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

    public void Add(EStatType type, int level)
    {
        var info = new UpgradeInfo(type, level);
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
