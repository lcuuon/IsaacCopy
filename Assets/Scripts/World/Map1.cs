using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1 : MonoBehaviour
{
    public bool stay;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            stay = true;
            Debug.Log("Stay");
        }
        else
        {
            stay = false;
            Debug.Log("Out");
        }
    }

    private void OnCollsionStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            stay = true;
            Debug.Log("Stay");
        }
        else
        {
            stay = false;
            Debug.Log("Out");
        }
    }
}
