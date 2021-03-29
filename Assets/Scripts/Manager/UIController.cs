using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController uiController;

    #pragma warning disable 0649

    [Header("UI Elements")]
    
    [SerializeField] private GameObject _levelEndCanvas;
    [SerializeField] private GameObject _tryAgainButton;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private TextMeshProUGUI _currentLevelText;

    #pragma warning restore 0649

    private void Awake()
    {
        uiController = this;
    }

    private void Start()
    {
        InitValues();
    }

    void InitValues()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            _currentLevelText.text = (PlayerPrefs.GetInt("CurrentLevel") + 1).ToString();
        }
        else
        {
            _currentLevelText.text = "1";
        }
    }

    public void OpenLevelEndCanvas()
    {
        _levelEndCanvas.SetActive(true);
    }

    public void TryAgainButtonPressed()
    {
        GameManager.gameManager.TryAgainButtonPressed();
    }

    public void NextLevelButtonPressed()
    {
        GameManager.gameManager.NextLevelButtonPressed();
    }

    public void LevelFailed()
    {
        _tryAgainButton.SetActive(true);
    }

    public void StartButtonPressed()
    {
        GameManager.gameManager.StartButtonPressed();
        _startButton.SetActive(false);
    }
}
