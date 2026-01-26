using System;
using UnityEngine;

public class ClickTarget : MonoBehaviour, IClickable
{
    [SerializeField] private string _name;

    public event Action OnClicked;

    public bool OnClick(ClickInfo info)
    {
        Debug.Log($"{_name} : {info.Damage}");
        
        OnClicked?.Invoke();
        
        return true;
    }
}
