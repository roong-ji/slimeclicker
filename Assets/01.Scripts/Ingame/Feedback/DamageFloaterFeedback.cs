using UnityEngine;

public class DamageFloaterFeedback : MonoBehaviour, IFeedback
{
    public void Play(ClickInfo info)
    {
        DamageFloaterSpawner.Instance.ShowDamage(info);
    }
}
