using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] UnityEvent OnReceiveDamage;
    [SerializeField] UnityEvent OnDead;

    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }
    
    public void ReceiveDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        OnReceiveDamage?.Invoke();

        if(CurrentHealth <= 0)
            OnDead?.Invoke();
    }

}
