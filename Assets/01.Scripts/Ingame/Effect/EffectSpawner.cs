using Lean.Pool;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public static EffectSpawner Instance {get; private set;}

    [SerializeField] private LeanGameObjectPool _clickEffectPool;
    [SerializeField] private LeanGameObjectPool _spawnEffectPool;
    [SerializeField] private LeanGameObjectPool _despawnEffectPool;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowClickEffect(Vector3 position)
    {
        GameObject effectObject = _clickEffectPool.Spawn(position, Quaternion.identity, transform);
    }

    public void ShowSpawnEffect(Vector3 position)
    {
        GameObject effectObject = _spawnEffectPool.Spawn(position, Quaternion.identity, transform);
    }

    public void ShowDespawnEffect(Vector3 position)
    {
        GameObject effectObject = _despawnEffectPool.Spawn(position, Quaternion.identity, transform);
    }
}
