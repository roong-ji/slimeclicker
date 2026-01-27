using UnityEngine;

public struct ClickInfo
{
    public EClickType Type;
    public double Damage;
    public Vector2 Point;

    public ClickInfo(EClickType type, double damage, Vector2 point = default)
    {
        Type = type;
        Damage = damage;
        Point = point;
    }
}
