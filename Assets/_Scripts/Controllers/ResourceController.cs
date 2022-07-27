using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private int _startGoldAmount = 100;
    [SerializeField] private int _increaseMoneyAmount = 10;
    [SerializeField] private int _increaseMoneyDelayTime = 1;
    [Header("Other attributes")]
    [SerializeField] private ResourceData _resourceData;
    [SerializeField] private UnityEvent<int> OnMoneyAmountChange;

    private int _money = 100;
    private int _cost;

    public int Money { get => _money; set => _money = value; }

    private void Start()
    {
        _money = _startGoldAmount;
        StartCoroutine(IncreaseMoneyRoutine());
    }

    private IEnumerator IncreaseMoneyRoutine()
    {
        while (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
        {
            yield return new WaitForSeconds(_increaseMoneyDelayTime);
            Money += _increaseMoneyAmount;
            OnMoneyAmountChange?.Invoke(Money);
        }
    }

    public void SubtractWeaponCost(string weaponType)
    {
        switch (weaponType)
        {
            case "Gun":
                _cost = _resourceData.WeaponCosts[0].Cost; //Gun
                break;
            case "Cannon":
                _cost = _resourceData.WeaponCosts[1].Cost; //Cannon
                break;
            case "LaserTurret":
                _cost = _resourceData.WeaponCosts[2].Cost; //Laser turret
                break;
            default:
                Debug.LogError($"Weapon type \"{weaponType}\" is not valid.");
                break;
        }

        Money -= _cost;
        OnMoneyAmountChange?.Invoke(Money);

    }
}
