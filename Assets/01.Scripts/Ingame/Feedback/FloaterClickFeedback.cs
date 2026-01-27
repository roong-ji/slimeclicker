using UnityEngine;

public class FloaterClickFeedback : MonoBehaviour, IClickFeedback, IDespawnFeedback
{
    public void Play(ClickInfo info)
    {
        FloaterSpawner.Instance.ShowDamage(info);
    }

    public void OnDespawn()
    {
        double gold = GameManager.Instance.GoldReward.Amount;
        FloaterSpawner.Instance.ShowGold(gold, transform.position);
    }
}
