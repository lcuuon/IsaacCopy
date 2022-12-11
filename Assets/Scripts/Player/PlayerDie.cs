using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    void Start()
    {
        Invoke("Des",0.5831f);
    }

    void Des()
    {
        Destroy(gameObject);
    }

}
