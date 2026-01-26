using UnityEngine;

public class ClickTarget : MonoBehaviour, IClickable
{
    [SerializeField] private string _name;

    public bool OnClick(ClickInfo info)
    {
        Debug.Log($"{_name} : {info.Damage}");
        return true;
    }
}
