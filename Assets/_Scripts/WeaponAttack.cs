using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponAttack : MonoBehaviour, IAudioPlayable
{
    [SerializeField] Transform _weaponBarrel;
    [SerializeField] private int _damageAmount;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _rayLength = 20f;
    [SerializeField] private ShootType _shootType;
    [SerializeField] private AudioSFX _shotSFX;
    [SerializeField] private UnityEvent OnShoot;
    [Header("Projectile attributes")]
    [SerializeField] private GameObject _prefabProjectile;
    [SerializeField] Transform _projectileSpawnPoint;

    private AudioController _audioController;
    private enum ShootType
    {
        Ray,
        Projectile,
    }

    private void Awake()
    {
        _audioController = FindObjectOfType<AudioController>();
    }

    public void StartWeaponAttack()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
        {
            Ray ray = new Ray(_weaponBarrel.position, _weaponBarrel.forward);

            if(Physics.Raycast(ray, out RaycastHit hitInfo, _rayLength))
            {
                if (hitInfo.collider.CompareTag(GameConstants.Tag.Enemy))
                {
                    if (_shootType.Equals(ShootType.Projectile))
                    {
                        Instantiate(_prefabProjectile, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
                        _shotSFX.PlayAudio();
                    }
                    else
                    {
                        if (hitInfo.collider.TryGetComponent<Health>(out Health enemyHealth))
                        {
                            enemyHealth.ReceiveDamage(_damageAmount);
                        }
                    }

                    OnShoot?.Invoke();
                }

                Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);

                yield return new WaitForSeconds(_attackCooldown);
            }
            else
            {
                yield return null;
                Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.yellow);
            }
        }
    }

    public void PlaySFX(string audioName)
    {
        _audioController.PlayAudio(audioName);
    }
}
