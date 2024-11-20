using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int time = 60;
    public GameObject pausePanel;
    bool paused;

    public int points;
    public int redKeys, greenKeys, goldKeys;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void Stopper()
    {
        time--;
        if(time < 1)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        CancelInvoke();
        Debug.Log("Game Over");
    }

    public void AddTime(int timeToAdd)
    {
        time += timeToAdd;
        if (time < 1)
            time = 1;
    }

    public void AddKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red:
                redKeys++;
                break;
            case KeyColor.Green:
                greenKeys++;
                break;
            case KeyColor.Gold:
                goldKeys++;
                break;
        }
    }

    public void FreezeTime(int time)
    {
        CancelInvoke();
        InvokeRepeating(nameof(Stopper), time, 1);
    }

    internal void UseKey(KeyColor key)
    {
        switch (key)
        {
            case KeyColor.Red:
                redKeys--;
                break;
            case KeyColor.Green:
                greenKeys--;
                break;
            case KeyColor.Gold:
                goldKeys--;
                break;
        }
    }

    internal bool HasKey(KeyColor properKey)
    {
        switch (properKey)
        {
            case KeyColor.Red:
                return redKeys > 0;
            case KeyColor.Green:
                return greenKeys > 0;
            case KeyColor.Gold:
                return goldKeys > 0;
        }
        return false;
    }
}
