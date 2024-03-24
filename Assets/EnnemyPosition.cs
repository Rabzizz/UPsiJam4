using UnityEngine;

public class EnnemyPosition : MonoBehaviour
{
    public Transform enemy;

    public GameObject enemyPawn;

    // who cares whatever works ffs
    private const float yPosition = 1.37f;
    private const int xOffset = 19;
    private const float factor = 0.0165f;

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        if (enemy == null)
            return;
        enemyPawn.transform.localPosition = new Vector3((enemy.localPosition.x + xOffset) * factor, yPosition, enemy.localPosition.z * factor);
    }


}
