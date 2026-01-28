using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    
    public static Tooltip Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        transform.localScale = Vector3.one;
    }

    public void Show(string text)
    {
        _textUI.SetText(text);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
