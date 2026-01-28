using UnityEngine;

public class EffectFeedback : MonoBehaviour, IClickFeedback, ISpawnFeedback, IDespawnFeedback
{
    public void Play(ClickInfo info)
    {
        if (info.Type == EClickType.Manual)
        {
            EffectSpawner.Instance.ShowClickEffect(info.Point);
        }
        else if (info.Type == EClickType.Auto)
        {
            EffectSpawner.Instance.ShowAutoClickEffect(transform.position);
        }
        else
        {
            EffectSpawner.Instance.ShowFeverClickEffect(transform.position);
        }
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
