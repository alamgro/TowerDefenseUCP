using UnityEngine;

public class ApplyTorque : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _minimumTorque;
    [SerializeField] private float _maximumTorque;
    [SerializeField] private bool _applyOnAwake;

    private Vector3 _finalTorqueVector;

    private void Awake()
    {
        if (_applyOnAwake)
        {
            ApplyForceVector();
        }
    }

    [ContextMenu("Apply Torque")]
    public void ApplyForceVector()
    {
        //Random direction
        _finalTorqueVector = Random.onUnitSphere;
        //Random torque
        _finalTorqueVector *= Random.Range(_minimumTorque, _maximumTorque);
        //Add torque to Rigidbody
        _rigidbody.AddTorque(_finalTorqueVector, _forceMode);
    }
}
