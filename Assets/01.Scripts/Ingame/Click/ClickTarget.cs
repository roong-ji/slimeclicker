using UnityEngine;

public class ClickTarget : MonoBehaviour, IClickable
{
    [SerializeField] private string _name;

    public bool OnClick()
    {
        Debug.Log($"{_name} : 아야");
        return true;
    }
}
