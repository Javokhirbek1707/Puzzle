using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] 
    private GameObject _mainMenu;
    [SerializeField] 
    private GameObject _loginMenu;
    [SerializeField] 
    private GameObject _createMenu;
    [SerializeField] 
    private GameObject _optionsMenu;
    [SerializeField] 
    private GameObject _gamesMenu;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (GameManager.Instance != null && !string.IsNullOrEmpty(GameManager.Instance.desiredMenuPanel))
        {
            if (GameManager.Instance.gamesMenuPanel == "Games")
            {
                ShowGames();
            }
            GameManager.Instance.gamesMenuPanel = "";
        }
        else
        {
            ShowMainMenu();
        }
    }


    public void DisableAll()
    {
        _mainMenu.SetActive(false);
        _loginMenu.SetActive(false);
        _createMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _gamesMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        DisableAll();
        _mainMenu.SetActive(true);
    }

    public void ShowLogin()
    {
        DisableAll();
        _loginMenu.SetActive(true);
    }

    public void ShowCreate()
    {
        DisableAll();
        _createMenu.SetActive(true);
    }

    public void ShowOptions()
    {
        DisableAll();
        _optionsMenu.SetActive(true);
    }

    public void ShowGames()
    {
        DisableAll();
        _gamesMenu.SetActive(true);
    }
}
