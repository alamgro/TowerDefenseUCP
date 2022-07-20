using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private string _tagToCompare = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagToCompare))
        {
            if(other.TryGetComponent(out Health health))
            {
                health = other.GetComponent<Health>();
                health.ReceiveDamage(_damageAmount);
            }
        }
    }
}
