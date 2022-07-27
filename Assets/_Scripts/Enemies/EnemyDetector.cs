using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private Transform _detectedTarget;
    [SerializeField] private string _tagToDetect = "Enemy";
    [SerializeField] private float _attackRange;
    [SerializeField] private UnityEvent<Transform> OnEnemyDetected;
    [SerializeField] private UnityEvent OnEnemyLost;

    void Update()
    {
        if(_detectedTarget != null)
        {
            float distance = Vector3.Distance(transform.position, _detectedTarget.position);

            if(distance > _attackRange)
            {
                _detectedTarget = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(_detectedTarget == null && other.CompareTag(_tagToDetect))
        {
            _detectedTarget = other.transform;
            OnEnemyDetected?.Invoke(_detectedTarget);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(_attackRange > 0)
            Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
