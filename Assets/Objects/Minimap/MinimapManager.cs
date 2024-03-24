using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class MinimapManager : MonoBehaviour
{
    public GameObject enemyPosition;

    public static MinimapManager Instance { get; private set; }

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

    }

    void Start()
    {
        enemyPosition = gameObject.transform.GetChild(0).gameObject;
        enemyPosition.SetActive(false);
    }

    public void ViewEnemyOnMap()
    {
        SetEnemyBip(true);
        LeanTween.delayedCall(3f, x => SetEnemyBip(false));
    }

    private void SetEnemyBip(bool state)
    {
        enemyPosition.SetActive(state);
    }
}
