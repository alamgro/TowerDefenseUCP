using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabGun;
    [SerializeField] private GameObject _prefabCannon;
    [SerializeField] private GameObject _prefabLazerTurret;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _weaponSlotLayerMask;
    [SerializeField] private UnityEvent<string> OnWeaponPurchased;

    private GameObject _temporalHeldWeapon;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        StartCoroutine(HeldWeaponRoutine());
    }

    public void CreateWeapon(string weaponType)
    {
        if (_temporalHeldWeapon != null) return;

        switch (weaponType)
        {
            case "Gun":
                _temporalHeldWeapon = Instantiate(_prefabGun);
                break;
            case "Cannon":
                _temporalHeldWeapon = Instantiate(_prefabCannon);
                break;
            case "LaserTurret":
                _temporalHeldWeapon = Instantiate(_prefabLazerTurret);
                break;
            default:
                Debug.LogError($"Weapon type \"{weaponType}\" is not valid.");
                break;
        }

        OnWeaponPurchased?.Invoke(weaponType);
    }

    private IEnumerator HeldWeaponRoutine()
    {
        while(GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
        {
            if(_temporalHeldWeapon != null)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, _raycastDistance, _groundLayerMask))
                {
                    _temporalHeldWeapon.transform.position = hitInfo.point;
                    if (Input.GetMouseButtonDown(0) 
                        && hitInfo.collider.CompareTag("WeaponSlot") 
                        && hitInfo.transform.childCount == 0)
                    {
                        _temporalHeldWeapon.transform.position = hitInfo.transform.position;
                        //Set weapon parent
                        _temporalHeldWeapon.transform.SetParent(hitInfo.collider.transform);
                        //Start weapon attack
                        _temporalHeldWeapon.GetComponent<WeaponAttack>().StartWeaponAttack();
                        //Place weapon
                        _temporalHeldWeapon = null;
                    }
                }

                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(_temporalHeldWeapon);
                    _temporalHeldWeapon = null;
                }
            }
            yield return null;
        }
    }

}
