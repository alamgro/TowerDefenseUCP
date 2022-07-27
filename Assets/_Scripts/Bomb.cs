using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 50;
    [SerializeField] private float _initialBlinkDelay = 1f;
    [SerializeField] private float _blinkDuration = 0.1f;
    [SerializeField] private float _blinkDelayDecreaseRate = 0.1f;
    [SerializeField] private float _delayBeforeExplotion = 1f;
    [SerializeField] private string _tagToCompare = "Weapon";
    [SerializeField] private Renderer _renderer;
    [SerializeField] private List<Transform> _damageList = new List<Transform>();
    [SerializeField] private UnityEvent OnExploded;


    private void Start()
    {
        _renderer.material.SetColor("_EmissionColor", Color.black);

        StartCoroutine(ExplodeRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagToCompare))
        {
            _damageList.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_tagToCompare))
        {
            _damageList.Remove(other.transform);
        }
    }

    public IEnumerator ExplodeRoutine()
    {
        float blinkDelay = _initialBlinkDelay;

        while (blinkDelay > 0f)
        {
            yield return new WaitForSeconds(blinkDelay);
            _renderer.material.SetColor("_EmissionColor", Color.white);
            yield return new WaitForSeconds(_blinkDuration);
            _renderer.material.SetColor("_EmissionColor", Color.black);

            blinkDelay -= _blinkDelayDecreaseRate;
        }

        _renderer.material.SetColor("_EmissionColor", Color.white);
        yield return new WaitForSeconds(_delayBeforeExplotion);

        //Debug.Log("Exploded!");
        foreach (var weapon in _damageList)
        {
            if(weapon.TryGetComponent<Health>(out Health health))
            {
                health.ReceiveDamage(_damageAmount);
            }
        }

        OnExploded?.Invoke();
    }
}
