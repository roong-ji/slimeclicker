using System.Collections.Generic;
using UnityEngine;

public class ClickTarget : MonoBehaviour, IClickable
{
    [SerializeField] private string _name;

    private List<IFeedback> _feedbacks;
    
    private void Awake()
    {
        _feedbacks = new List<IFeedback>(GetComponents<IFeedback>());
    }

    public bool OnClick(ClickInfo info)
    {
        Debug.Log($"{_name} : {info.Damage}");

        foreach (var feedback in _feedbacks)
        {
            feedback.Play();
        }
        
        return true;
    }
}
