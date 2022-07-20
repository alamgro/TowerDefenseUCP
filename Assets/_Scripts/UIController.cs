using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;

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
}
