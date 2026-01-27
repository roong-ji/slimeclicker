using Lean.Pool;
using UnityEngine;

public class DamageFloaterSpawner : MonoBehaviour
{
    public static DamageFloaterSpawner Instance {get; private set;}

    [SerializeField] private LeanGameObjectPool _pool;

    private void Awake()
    {
        Instance = this;
        _pool = GetComponent<LeanGameObjectPool>();
    }

    public void ShowDamage(ClickInfo info)
    {
        GameObject floaterObject = _pool.Spawn(info.Point, Quaternion.identity);
        if (!floaterObject.TryGetComponent(out DamageFloater floater)) return;
        floater.Show(info.Damage);
    }
}
