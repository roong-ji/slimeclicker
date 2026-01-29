using System;

public interface IReadOnlyValue
{
    double Amount { get; }
    event Action<double> OnChanged;
}