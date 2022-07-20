using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private string _tagToCompare = "Player";
    [SerializeField] private UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagToCompare))
        {
            if(other.TryGetComponent(out Health health))
            {
                health.ReceiveDamage(_damageAmount);
                onTrigger?.Invoke();
            }
        }
    }
}
