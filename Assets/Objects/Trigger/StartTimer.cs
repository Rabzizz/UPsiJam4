using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public DayCycleManager dayCycleManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dayCycleManager.StartDayTimer();
        }
        else if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.ChangeGameState(GameState.GameOver);
        }
    }
}
