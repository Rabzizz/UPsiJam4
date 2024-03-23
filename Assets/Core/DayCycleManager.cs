using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [SerializeField] float dayDuration = 300;
    [SerializeField] float nightDuration = 300;
    [SerializeField] bool dayTimerRunning;
    [SerializeField] bool nightTimerRunning;
    [SerializeField] int dayToWin = 5;
    public float dayTimer;
    public float nightTimer;
    public int numberOfDaySurvived = 0;


    void Start()
    {
        GameManager.Instance.onGameStateChanged += OnGameStateChanged;
        dayTimer = dayDuration;
        nightTimer = nightDuration;
    }

    void Update()
    {
        if (dayTimerRunning)
        {
            dayTimer -= Time.deltaTime;
        }

        if (dayTimer < 0)
        {
            dayTimerRunning = false;
            dayTimer = 0;
            GameManager.Instance.ChangeGameState(GameState.Phase2);
        }

        if (nightTimerRunning)
        {
            nightTimer -= Time.deltaTime;
        }

        if (nightTimer < 0)
        {
            nightTimerRunning = false;
            nightTimer = 0;
            GameManager.Instance.ChangeGameState(GameState.Phase1);
        }
    }

    public void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Phase1:
                dayTimer = dayDuration;
                if (++numberOfDaySurvived > dayToWin)
                {
                    GameManager.Instance.ChangeGameState(GameState.Win);
                }
                
                break;
            case GameState.Phase2:
                nightTimer = nightDuration;
                nightTimerRunning = true;
                break;
            default:
                break;
        }
    }

    public void StartDayTimer()
    {
        dayTimerRunning = true;
    }
}
