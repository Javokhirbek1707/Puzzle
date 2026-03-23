using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerGame : MonoBehaviour
{
    [SerializeField]private GameObject _sound;
    private bool _menuActive = false;

    private void Start()
    {
        SwitchMenu();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOffMenu();
        }
    }

    public void TurnOffMenu()
    {
        _menuActive = !_menuActive;
        if (_menuActive == true)
        {
            Time.timeScale = 0;
            SwitchMenu();
        }
        if(_menuActive == false)
        {
            Time.timeScale = 1;
            SwitchMenu();
        }
    }

    public void SwitchMenu()
    {
        if(_menuActive == true)
        {
            _sound.SetActive(true);
        }
        if(_menuActive == false)
        {
            _sound.SetActive(false);
        }
    }

    public void ReplayGameOne()
    {
        SceneManager.LoadScene(1);
    }

    public void ReplayGameTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void ReplayGameThree()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
