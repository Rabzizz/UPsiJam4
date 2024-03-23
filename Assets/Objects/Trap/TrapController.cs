using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour, IActivable
{
    public void Activate()
    {
        Debug.Log("Activate trap");
    }

}
