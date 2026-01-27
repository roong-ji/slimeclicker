using UnityEngine;

public class EffectFeedback : MonoBehaviour, IClickFeedback, ISpawnFeedback, IDespawnFeedback
{
    public void Play(ClickInfo info)
    {
        EffectSpawner.Instance.ShowClickEffect(info.Point);
    }
    
    public void OnSpawn()
    {
        EffectSpawner.Instance.ShowSpawnEffect(transform.position);
    }

    public void OnDespawn()
    {
        EffectSpawner.Instance.ShowDespawnEffect(transform.position);
    }
}
