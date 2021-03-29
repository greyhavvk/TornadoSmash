using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    #pragma warning disable 0649

    [Header("References")]

    [SerializeField] private Transform _LvlDesign;

    #pragma warning restore 0649

    private bool finish = false;

    private void Awake()
    {
        gameManager = this;
    }

    void Update()
    {
        ControlGameFinished();
    }

    private void ControlGameFinished()
    {
        if (!finish)
        {
            checkRemainingCube();
        }
    }

    public void TriggerStart()
    {
        MovementController.movementController.TriggerStart();
    } 

    void SetLevelCounter()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    public void checkRemainingCube()
    {
        if (_LvlDesign.childCount <= 0)
        {
            LevelSuccess();
        }
    }

    public void LevelSuccess()
    {
        finish = true;
        UIController.uiController.OpenLevelEndCanvas();
        SetLevelCounter();
        AudioController.audioController.PlayFinishSFX();
    }

    public void TryAgainButtonPressed()
    {
        SceneManager.LoadScene("TornadoSmash");
    }

    public void NextLevelButtonPressed()
    {
        SceneManager.LoadScene("TornadoSmash");
    }

    public void StartButtonPressed()
    {
        TriggerStart();
    }

}