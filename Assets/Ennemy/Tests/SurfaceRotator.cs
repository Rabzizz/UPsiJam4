using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class SurfaceRotator : MonoBehaviour
{
    private void Update()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 15 * Time.deltaTime, 0) + transform.localRotation.eulerAngles);
    }
}
