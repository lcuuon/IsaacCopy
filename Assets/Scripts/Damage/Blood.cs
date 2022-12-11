using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    void Start()
    {
        Invoke("AutoDes", 10f);
    }

    void AutoDes()
    {
        Destroy(gameObject);
    }

    
}
