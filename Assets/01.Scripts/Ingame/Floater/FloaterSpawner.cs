using Lean.Pool;
using UnityEngine;

public class FloaterSpawner : MonoBehaviour
{
    public static FloaterSpawner Instance {get; private set;}

    [SerializeField] private LeanGameObjectPool _damagePool;
    [SerializeField] private LeanGameObjectPool _goldPool;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDamage(ClickInfo info)
    {
        GameObject floaterObject = _damagePool.Spawn(info.Point, Quaternion.identity);
        if (!floaterObject.TryGetComponent(out DamageFloater floater)) return;
        floater.Show(info.Damage);
    }

    public void ShowGold(double gold, Vector3 position)
    {
        GameObject floaterObject = _goldPool.Spawn(position, Quaternion.identity);
        if (!floaterObject.TryGetComponent(out GoldFloater floater)) return;
        floater.Show(gold);
    }
}
