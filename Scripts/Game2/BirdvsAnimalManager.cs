using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdvsAnimalManager : MonoBehaviour
{
    public static BirdvsAnimalManager Instance;

    [Header("Timer")]
    [SerializeField] 
    private TMP_Text _timerText;
    private float _seconds;
    private bool _isTimerActive;

    [Header("Win Screen")]
    [SerializeField] 
    private TMP_Text _finalTimeText;
    [SerializeField] 
    private TMP_Text _quickestTimeText;
    [SerializeField] 
    private GameObject _winScreen;
    [SerializeField] 
    private GameObject _animals;
    [SerializeField] 
    private GameObject _birds;

    private float _fastestTime;

    [SerializeField] 
    private int _totalCorrectDrops = 15;
    private int _currentCorrectDrops;

    private bool _openedWinScene;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _isTimerActive = true;
        _openedWinScene = false;

        _fastestTime = PlayerPrefs.GetFloat("BirdGameFastest", 0);
    }

    private void Update()
    {
        if (!_isTimerActive) return;

        _seconds += Time.deltaTime;
        _timerText.SetText(((int)_seconds).ToString());
    }

    public void RegisterCorrectDrop()
    {
        _currentCorrectDrops++;

        if (_currentCorrectDrops >= _totalCorrectDrops)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (_openedWinScene) return;

        _isTimerActive = false;
        _openedWinScene = true;

        GameWin();
    }

    private void GameWin()
    {
        _winScreen.SetActive(true);

        int finalTime = (int)_seconds;
        _finalTimeText.SetText(finalTime.ToString());

        if (_fastestTime == 0 || finalTime < _fastestTime)
        {
            _fastestTime = finalTime;
            PlayerPrefs.SetFloat("BirdGameFastest", _fastestTime);
        }

        _quickestTimeText.SetText(((int)_fastestTime).ToString());
        _animals.SetActive(false);
        _birds.SetActive(false);
    }
}