using UnityEngine;

public struct ClickInfo
{
    public EClickType ClickType;
    public int Damage;

    public ClickInfo(EClickType clickType, int damage)
    {
        ClickType = clickType;
        Damage = damage;
    }
}
