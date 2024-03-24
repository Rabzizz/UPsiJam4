using UnityEngine;

public class EnnemyPosition : MonoBehaviour
{
    Vector3 enemy;

    public GameObject enemyPawn;

    // who cares whatever works ffs
    private const float yPosition = 1.37f;
    private const int xOffset = 19;
    private const float factor = 0.0165f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform.localPosition;
        if (enemy == null)
            return;
        enemyPawn.transform.localPosition = new Vector3((enemy.x + xOffset) * factor, yPosition, enemy.z * factor);
    }


}
