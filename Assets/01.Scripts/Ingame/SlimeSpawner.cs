using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private List<ClickTarget> _slimes;
    public List<ClickTarget> Slimes => _slimes;
}
