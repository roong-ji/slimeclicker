using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SlimeMovement : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float _jumpPower = 0.5f;     // 점프 높이
    [SerializeField] private float _jumpDuration = 0.4f;  // 점프 속도
    [SerializeField] private float _minWaitTime = 1f;     // 최소 대기 시간
    [SerializeField] private float _maxWaitTime = 3f;     // 최대 대기 시간
    [SerializeField] private float _moveRange = 1f;       // 한 번에 이동할 최대 거리

    private BoxCollider2D _spawnArea;
    private bool _isMoving = false;
    private ClickTarget _clickTarget;

    private void Awake()
    {
        _clickTarget = GetComponent<ClickTarget>();
    }

    public void SetMoveArea(BoxCollider2D area)
    {
        _spawnArea = area;
        StartCoroutine(MoveRoutine());
    }

    private void OnEnable()
    {
        _isMoving = false;
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            // 1. 랜덤 시간 대기
            yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));

            // 만약 죽었거나 비활성화 중이면 중단
            if (gameObject.activeSelf == false) yield break;

            // 2. 목적지 결정 (영역 내부인지 확인)
            Vector2 targetPos = GetValidTargetPos();

            // 3. 점프 이동
            _isMoving = true;
            
            // 좌우 반전 (이동 방향에 따라 스프라이트 돌리기)
            float direction = targetPos.x - transform.position.x;
            if (Mathf.Abs(direction) > 0.1f)
                transform.localScale = new Vector3(direction > 0 ? -1 : 1, 1, 1);

            // DOJump(목적지, 점프력, 점프횟수, 시간)
            transform.DOJump(targetPos, _jumpPower, 1, _jumpDuration)
                     .SetEase(Ease.OutQuad)
                     .OnComplete(() => _isMoving = false);

            yield return new WaitUntil(() => !_isMoving);
        }
    }

    private Vector2 GetValidTargetPos()
    {
        Vector2 randomDir = Random.insideUnitCircle * _moveRange;
        Vector2 targetPos = (Vector2)transform.position + randomDir;

        if (_spawnArea != null)
        {
            Bounds bounds = _spawnArea.bounds;
            targetPos.x = Mathf.Clamp(targetPos.x, bounds.min.x, bounds.max.x);
            targetPos.y = Mathf.Clamp(targetPos.y, bounds.min.y, bounds.max.y);
        }

        return targetPos;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        transform.DOKill();
    }
}
