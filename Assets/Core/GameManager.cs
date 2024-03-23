
using System;
using UnityEngine;

public enum GameState
{
    Phase1,
    Phase2,
    Win,
    GameOver
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    public static GameManager Instance { get; private set; }
    public event Action<GameState> onGameStateChanged;
    public GameObject enemyPrefab;
    public GameObject enemy;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

    }

    public void ChangeGameState(GameState gameState)
    {
        Debug.Log(gameState.ToString());
        switch (gameState)
        {
            case GameState.Phase1:
                Destroy(enemy);
                break;
            case GameState.Phase2:
                enemy = Instantiate(enemyPrefab);
                enemy.GetComponent<EnnemyController>().follow = true;
                break;
            default:
                break;
        }
        onGameStateChanged?.Invoke(gameState);
    }


}