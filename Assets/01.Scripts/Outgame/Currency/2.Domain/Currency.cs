using System;
using UnityEngine;

[Serializable]
public struct Currency
{
    public double Value;

    public Currency(double value)
    {
        if (value < 0)
        {
            throw new Exception("Currency 값은 0보다 작을 수 없습니다.");
        }
        Value = value;
    }

    public static Currency operator +(Currency left, Currency right)
    {
        return new Currency(left.Value + right.Value);
    }

    public static Currency operator -(Currency left, Currency right)
    {
        return new Currency(left.Value - right.Value);
    }
    
    public static bool operator >=(Currency left, Currency right)
    {
        return left.Value >= right.Value;
    }

    public static bool operator <=(Currency left, Currency right)
    {
        return left.Value <= right.Value;
    }

    public static bool operator >(Currency left, Currency right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(Currency left, Currency right)
    {
        return left.Value < right.Value;
    }
    
    // double → Currency 암시적 변환    
    public static implicit operator Currency(double value)
    {
        return new Currency(value);
    }
    
    // Currency -> double 암시적 변환
    public static explicit operator double(Currency currency)
    {
        return currency.Value;
    }

    public override string ToString() => Value.ToUnitString();
}