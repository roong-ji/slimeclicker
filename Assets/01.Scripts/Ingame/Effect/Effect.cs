using UnityEngine;
using Lean.Pool;

public class Effect : MonoBehaviour
{
    private void OnAnimationEnd()
    {
        LeanPool.Despawn(gameObject);
    }
}
