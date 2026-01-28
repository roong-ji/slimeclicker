using UnityEngine;

public class SlimesLobby : MonoBehaviour
{
    [SerializeField] private SlimeMovement[] _slimes;
    [SerializeField] private BoxCollider2D _spawnArea;
    
    private void Awake()
    {
        foreach (var slime in _slimes)
        {
            slime.SetMoveArea(_spawnArea);
        }
    }
}
