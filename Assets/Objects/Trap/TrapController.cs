using UnityEngine;

public class TrapController : MonoBehaviour, IActivable
{
    bool ennemyIsInTrigger = false;
    EnnemyController ennemy;

    public void Activate()
    {
        Debug.Log("Activate trap");

        if (ennemyIsInTrigger)
            ennemy.HitFromTrap();
    }

    private void OnTriggerEnter(Collider other)
    {
        ennemyIsInTrigger = other.gameObject.TryGetComponent(out ennemy);
        Activate();
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        ennemyIsInTrigger = false;
        ennemy = null;
    }
}
