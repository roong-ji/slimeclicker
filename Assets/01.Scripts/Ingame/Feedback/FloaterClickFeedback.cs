using UnityEngine;

public class FloaterClickFeedback : MonoBehaviour, IClickFeedback, IDespawnFeedback
{
    public void Play(ClickInfo info)
    {
        if (info.Type != EClickType.Manual)
        {
            info.Point = transform.position;
        }
        FloaterSpawner.Instance.ShowDamage(info);
    }

    public void OnDespawn()
    {
        double gold = GameManager.Instance.GoldReward.Amount;
        FloaterSpawner.Instance.ShowGold(gold, transform.position);
    }
}
