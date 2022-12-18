using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart1 : MonoBehaviour
{
    PlayerDamage pd;
    Animator ani;

    void Start()
    {
        pd = GameObject.Find("Player").GetComponent<PlayerDamage>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(pd.HP == 6)
        {
            Debug.Log("HpDown");
            ani.SetBool("heart1", false);
        }
        if(pd.HP == 5)
        {
            ani.SetBool("heart2", false);
            ani.SetBool("heart1", true);
        }
        if(pd.HP == 4)
        {
            ani.SetBool("heart2", true);
        }
    }
}
