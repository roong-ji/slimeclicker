using Lean.Pool;
using UnityEngine;

public class FloaterSpawner : MonoBehaviour
{
    public static FloaterSpawner Instance {get; private set;}

    [SerializeField] private LeanGameObjectPool _damagePool;
    [SerializeField] private LeanGameObjectPool _goldPool;
    [SerializeField] private float _offsetRange = 0.5f;
        
    private void Awake()
    {
        Instance = this;
    }

    public void ShowDamage(ClickInfo info)
    {
        if (info.Type == EClickType.Manual)
        {
            var randomOffset = Random.insideUnitCircle * _offsetRange;
            info.Point += randomOffset;
        }
        
        var floaterObject = _damagePool.Spawn(info.Point, Quaternion.identity, transform);
        if (!floaterObject.TryGetComponent(out DamageFloater floater)) return;
        floater.Show(info.Damage);
    }

    public void ShowGold(double gold, Vector3 position)
    {
        var floaterObject = _goldPool.Spawn(position, Quaternion.identity, transform);
        if (!floaterObject.TryGetComponent(out GoldFloater floater)) return;
        floater.Show(gold);
    }
}
