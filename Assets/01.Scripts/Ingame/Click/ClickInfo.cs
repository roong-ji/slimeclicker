using UnityEngine;

public struct ClickInfo
{
    public EClickType Type;
    public int Damage;
    public Vector2 Point;

    public ClickInfo(EClickType type, int damage, Vector2 point = default)
    {
        Type = type;
        Damage = damage;
        Point = point;
    }
}
