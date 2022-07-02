using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PipeSpawner _spawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] protected DeathScreen _deathScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _deathScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }


    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _deathScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _deathScreen.Close();
        _spawner.ResetPool();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _deathScreen.Open();
    }
}
