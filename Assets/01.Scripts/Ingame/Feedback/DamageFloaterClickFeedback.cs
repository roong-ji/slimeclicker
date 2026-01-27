using UnityEngine;

public class DamageFloaterClickFeedback : MonoBehaviour, IClickFeedback
{
    public void Play(ClickInfo info)
    {
        DamageFloaterSpawner.Instance.ShowDamage(info);
    }
}
