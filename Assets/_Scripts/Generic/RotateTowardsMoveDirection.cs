using UnityEngine;

public class RotateTowardsMoveDirection : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRadiansDelta;

    private Vector3 _lastPosition;
    private Vector3 _currentDirection;

    void Update()
    {
        _currentDirection = transform.position - _lastPosition;
        Vector3 targetDirection = Vector3.RotateTowards(transform.forward, _currentDirection, _maxRadiansDelta, Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), _rotationSpeed * Time.deltaTime);

        _lastPosition = transform.position;
    }
}
