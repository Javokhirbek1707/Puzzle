using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScipt : MonoBehaviour
{
    [Header("Create")]
    [SerializeField] 
    private TMP_InputField _createUsername;
    [SerializeField] 
    private TMP_Text _createDebug;

    [Header("Login")]
    [SerializeField]
    private TMP_InputField _loginUsername;
    [SerializeField] 
    private TMP_Text _loginDebug;

    private const string USERNAME_KEY = "USERNAME";

    public void CreateAccaunt()
    {
        string username = _createUsername.text;

        if (string.IsNullOrEmpty(username) || username.Length < 3)
        {
            _createDebug.text = "Username must be at least 3 characters!";
            return;
        }

        if (GameManager.Instance.ProfileExists(username))
        {
            _createDebug.text = "Profile already exists!";
            return;
        }

        GameManager.Instance.CreateProfile(username);

        _createDebug.text = "Account created!";
        UIManager.Instance.ShowLogin();
    }

    public void LoginAccaunt()
    {
        string inputUsername = _loginUsername.text;

        if (!GameManager.Instance.ProfileExists(inputUsername))
        {
            _loginDebug.text = "Profile not found!";
            return;
        }

        GameManager.Instance.LoadProfile(inputUsername);

        _loginDebug.text = "Logged in!";
        UIManager.Instance.ShowGames();
    }

    public void Create() => UIManager.Instance.ShowCreate();
    public void Login() => UIManager.Instance.ShowLogin();
    public void Options() => UIManager.Instance.ShowOptions();
    public void Cancel() => UIManager.Instance.ShowMainMenu();
    public void GameOne() => SceneManager.LoadScene(1);
    public void GameTwo() => SceneManager.LoadScene(2);
    public void GameThree() => SceneManager.LoadScene(3);

    public void Exit() => Application.Quit();

}
