using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public GameEvent OnGameFinishes = new GameEvent();
    public int TestScore = 0;
    private void Start()
    {
        TinySauce.OnGameStarted(levelNumber: PlayerPrefs.GetInt("FakeLevel").ToString());
    }

    public void CompleteStage(bool state)
    {
        if (state)
        {
            LevelManager.Instance.LoadNextLevel();
        }
        else
        {
            LevelManager.Instance.ReloadLevel();
        }

        TinySauce.OnGameFinished(state, TestScore, levelNumber: PlayerPrefs.GetInt("FakeLevel").ToString());
    }
}
public class GameEvent : UnityEvent<bool> { }