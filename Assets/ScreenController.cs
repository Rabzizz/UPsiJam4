using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.InitScreenMat(GetComponent<MeshRenderer>());
    }

}
