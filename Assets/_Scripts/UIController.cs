using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Button[] _weaponButtons;
    [SerializeField] private TMP_Text _textMoneyAmount;
    [SerializeField] private ResourceData _resourceData;

    public void ShowGameOverScreen()
    {
        if (GameManager.Instance.Win)
        {
            _winScreen.SetActive(true);
        }
        else
        {
            _loseScreen.SetActive(true);
        }
    }

    public void SliderValueChange(float value)
    {
        GameManager.Instance.GameTimeScale = value;
    }

    public void RetryGame()
    {
        SceneLoader.LoadScene(GameConstants.Scene.Game);
    }

    public void CheckEnoughMoneyForWeapon(int currentMoneyAmount)
    {
        foreach (Button button in _weaponButtons)
        {
            button.interactable = false;
        }

        if(currentMoneyAmount >= _resourceData.WeaponCosts[2].Cost)
        {
            for (int i = 0; i < 3; i++)
            {
                _weaponButtons[i].interactable = true;
            }
        }
        else if(currentMoneyAmount >= _resourceData.WeaponCosts[1].Cost)
        {
            for (int i = 0; i < 2; i++)
            {
                _weaponButtons[i].interactable = true;
            }
        }
        else if (currentMoneyAmount >= _resourceData.WeaponCosts[0].Cost)
        {
            _weaponButtons[0].interactable = true;
        }
    }

    public void UpdateMoneyAmountUI(int currentMoneyAmount)
    {
        _textMoneyAmount.text = $"Money: {currentMoneyAmount}";
    }
}
