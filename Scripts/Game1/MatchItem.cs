using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchItem : MonoBehaviour
{
    /*[Header("Match")]
    [SerializeField] private GameObject _item1;
    [SerializeField] private GameObject _item2;
    private int _matchedItems;

    [Header("Timer")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private ItemSpawn _itemSpawner;

    private float _seconds;
    private bool _isTimerActive;

    [Header("Win Screen")]
    [SerializeField] private TMP_Text _finalTimeText;
    [SerializeField] private TMP_Text _quickestTimeText;
    [SerializeField] private GameObject _winScreen;

    private float _fastestTime;
    private bool _openedWinScene;

    private void Start()
    {
        _isTimerActive = true;
        _openedWinScene = false;

        _fastestTime = PlayerPrefs.GetFloat("MatchGameFastest", 0);

        if (_itemSpawner == null)
            Debug.LogError("ItemSpawner is NULL!");
    }

    private void Update()
    {
        if (!_isTimerActive) return;

        _seconds += Time.deltaTime;
        _timerText.SetText(((int)_seconds).ToString());
    }

    public void Match(GameObject obj)
    {
        if (_item1 == null)
        {
            _item1 = obj;
            return;
        }

        _item2 = obj;

        if (_item1.name == _item2.name)
        {
            _matchedItems++;
            _item1 = null;
            _item2 = null;

            if (_matchedItems >= _itemSpawner.PairsToWin())
            {
                EndGame();
            }
        }
        else
        {
            StartCoroutine(CoverRoutine());
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
            PlayerPrefs.SetFloat("MatchGameFastest", _fastestTime);
        }

        _quickestTimeText.SetText(((int)_fastestTime).ToString());
    }

    IEnumerator CoverRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        _item1.GetComponent<Item>().CoverItem(false);
        _item2.GetComponent<Item>().CoverItem(false);

        _item1 = null;
        _item2 = null;
    }*/
    public static MatchItem Instance { get; private set; }

    [Header("Match")]
    [SerializeField] private GameObject _item1;
    [SerializeField] private GameObject _item2;
    private int _matchedItems;

    [Header("Timer")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private ItemSpawn _itemSpawner;
    private float _seconds;
    private bool _isTimerActive;

    [Header("Win Screen")]
    [SerializeField] private TMP_Text _finalTimeText;
    [SerializeField] private TMP_Text _quickestTimeText;
    [SerializeField] private GameObject _winScreen;
    private float _fastestTime;
    private bool _openedWinScene;

    private void Awake()
    {
        // Set up singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _isTimerActive = true;
        _openedWinScene = false;
        _fastestTime = PlayerPrefs.GetFloat("MatchGameFastest", 0);

        if (_itemSpawner == null)
            Debug.LogError("ItemSpawner is NULL!");
    }

    // ... rest of your code stays the same
    private void Update()
    {
        if (!_isTimerActive) return;
        _seconds += Time.deltaTime;
        _timerText.SetText(((int)_seconds).ToString());
    }

    public void Match(GameObject obj)
    {
        if (_item1 == null)
        {
            _item1 = obj;
            return;
        }

        _item2 = obj;

        if (_item1.name == _item2.name)
        {
            _matchedItems++;
            _item1 = null;
            _item2 = null;

            if (_matchedItems >= _itemSpawner.PairsToWin())
            {
                EndGame();
            }
        }
        else
        {
            StartCoroutine(CoverRoutine());
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
            PlayerPrefs.SetFloat("MatchGameFastest", _fastestTime);
        }

        _quickestTimeText.SetText(((int)_fastestTime).ToString());
    }

    IEnumerator CoverRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        _item1.GetComponent<Item>().CoverItem(false);
        _item2.GetComponent<Item>().CoverItem(false);
        _item1 = null;
        _item2 = null;
    }
}