using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _spawnArea;
    [SerializeField] private ClickTarget _slimePrefab;
    [SerializeField] private float _spawnSpeed;

    private List<ClickTarget> _slimePool = new();
    
    private List<ClickTarget> _slimes = new();
    public List<ClickTarget> Slimes => _slimes;
    
    private float _timer = 0;
    private int _count = 0;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < 1f / _spawnSpeed) return;
        
        Spawn();
        _timer = 0f;
    }

    private void Spawn()
    {
        ClickTarget slime = GetSlimeFromPool();
        
        slime.transform.position = GetRandomPosition();
        slime.gameObject.SetActive(true);
        slime.Initialize(1);
        
        if (slime.TryGetComponent(out SlimeMovement movement))
        {
            movement.SetMoveArea(_spawnArea);
        }
        
        _slimes.Add(slime);
        
        ++_count;
    }
    
    private ClickTarget GetSlimeFromPool()
    {
        foreach (var pooledSlime in _slimePool)
        {
            if (!pooledSlime.gameObject.activeSelf)
            {
                return pooledSlime;
            }
        }

        ClickTarget newSlime = Instantiate(_slimePrefab, transform);
        
        _slimePool.Add(newSlime);
        return newSlime;
    }
    
    private Vector2 GetRandomPosition()
    {
        if (_spawnArea == null) return transform.position;

        Bounds bounds = _spawnArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(x, y);
    }
}
