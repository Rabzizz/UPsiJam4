
using System;
using System.Collections.Generic;
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

    public List<MeshRenderer> screens;
    public List<Material> screenMaterials;
    public List<RenderTexture> screenTexture;
    public Material screenBaseMat;

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

    public void InitScreenMat(MeshRenderer meshRenderer)
    {
        meshRenderer.sharedMaterial = screenBaseMat;
    }

    public bool SetCCTVTarget(Camera camera)
    {
        if(screenTexture.Count > 0)
        {
            camera.targetTexture = screenTexture[0];
            screenMaterials[0].mainTexture = camera.targetTexture;
            screens[0].sharedMaterial = screenMaterials[0];
            screenTexture.RemoveAt(0);
            screens.RemoveAt(0);
            screenMaterials.RemoveAt(0);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReTakeTarget(Camera camera)
    {
        screenTexture.Add(camera.targetTexture);
    }

}