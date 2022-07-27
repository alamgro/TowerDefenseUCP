using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private Vector3 _minimumForceVector;
    [SerializeField] private Vector3 _maximumForceVector;

    [SerializeField] private bool _applyOnAwake;

    private Vector3 _finalForceVector;

    private void Awake()
    {
        
        if (_applyOnAwake)
        {
            ApplyForceVector();
        }
    }

    [ContextMenu("Apply Force")]
    public void ApplyForceVector()
    {
        //Random direction
        _finalForceVector = Random.onUnitSphere;

        //Always use a positive force unless the input vector says otherwise 
        _finalForceVector.y = Mathf.Abs(_finalForceVector.y);

        //Assign random force in each axis
        _finalForceVector.x *= Random.Range(_minimumForceVector.x, _maximumForceVector.x);
        _finalForceVector.y *= Random.Range(_minimumForceVector.y, _maximumForceVector.y);
        _finalForceVector.z *= Random.Range(_minimumForceVector.z, _maximumForceVector.z);

        _rigidbody.AddForce(_finalForceVector, _forceMode);
    }
}
