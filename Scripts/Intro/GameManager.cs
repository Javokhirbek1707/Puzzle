using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<string> _profiles = new List<string>();
    private string _currentProfile;
    private int _profileCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadProfiles();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadProfiles()
    {
        _profileCount = PlayerPrefs.GetInt("ProfileCount", 0);

        for (int i = 0; i < _profileCount; i++)
        {
            if (PlayerPrefs.HasKey($"ProfileName{i}"))
            {
                _profiles.Add(PlayerPrefs.GetString($"ProfileName{i}"));
            }
        }
    }

    public void CreateProfile(string profile)
    {
        if (_profiles.Contains(profile)) return;

        PlayerPrefs.SetString($"ProfileName{_profileCount}", profile);
        PlayerPrefs.SetInt("ProfileCount", _profileCount + 1);
        PlayerPrefs.Save();

        _profiles.Add(profile);
        _currentProfile = profile;
        _profileCount++;
    }

    public bool ProfileExists(string profile)
    {
        return _profiles.Contains(profile);
    }

    public void LoadProfile(string profile)
    {
        if (_profiles.Contains(profile))
        {
            _currentProfile = profile;
        }
    }

    public string GetCurrentProfile()
    {
        return _currentProfile;
    }
}

