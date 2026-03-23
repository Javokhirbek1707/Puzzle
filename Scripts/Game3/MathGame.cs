using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathGame : MonoBehaviour
{
    [Header("InputFieilds")]
    [SerializeField] private TMP_Text _number1Text, _number2Text, _total;
    [SerializeField] private TMP_InputField _input;
    private int _number1, _number2, _correctAnswer, _playerAnswer;

    [Header("Text")]
    [SerializeField] private TMP_Text _scoreText, _debugText;
    [SerializeField] private int _maxAnswers;
    [SerializeField] private Button _nextAnswerButton, _checkAnswerButton;
    private int _amountOfQuestions, _score;

    [Header("Score")]
    [SerializeField] private GameObject _gameOverPage;
    [SerializeField] private int _finalScore, _highscore;
    [SerializeField] private TMP_Text _finalScoreText, _highscoreText;


    void Start()
    {
        CreateQuestion();
        _scoreText.SetText(_score.ToString());
        _debugText.gameObject.SetActive(false);
        _gameOverPage.SetActive(false);
    }


    public void CreateQuestion()
    {
        _number1 = Random.Range(1, 6);
        _number1Text.SetText(_number1.ToString());
        _number2 = Random.Range(1, 6);
        _number2Text.SetText(_number2.ToString());

        _total.SetText("");
        _correctAnswer = _number1 + _number2;

        _input.text = "";
        _input.readOnly = false;

        _nextAnswerButton.interactable = false;
        _checkAnswerButton.interactable = true;
    }

    public void CheckAnswer()
    {
        if (string.IsNullOrEmpty(_input.text))
        {
            _debugText.gameObject.SetActive(true);
            return;
        }

        _debugText.gameObject.SetActive(false);
        _input.readOnly = true;
        _checkAnswerButton.interactable = false;

        _playerAnswer = int.Parse(_input.text);

        if (_playerAnswer == _correctAnswer)
        {
            _total.SetText(_playerAnswer.ToString());
            _score += 5;
            _total.color = Color.white;
        }
        else
        {
            _total.SetText(_correctAnswer.ToString());
            _total.color = Color.red;
            _score -= 3;
        }

        _scoreText.SetText(_score.ToString());
        _amountOfQuestions++;

        if (_amountOfQuestions >= _maxAnswers)
        {
            _finalScore = _score;
            GameOver();
            return;
        }

        _nextAnswerButton.interactable = true;
    }

    private void GameOver()
    {
        string profile = GameManager.Instance.GetCurrentProfile();

        if (string.IsNullOrEmpty(profile))
        {
            Debug.LogError("No profile loaded!");
            return;
        }

        _highscore = PlayerPrefs.GetInt(profile + "_MathHighScore", 0);

        _gameOverPage.SetActive(true);
        _finalScoreText.SetText(_finalScore.ToString());

        if (_finalScore > _highscore)
        {
            _highscore = _finalScore;
            PlayerPrefs.SetInt(profile + "_MathHighScore", _highscore);
        }

        _highscoreText.SetText(_highscore.ToString());
    }

}
