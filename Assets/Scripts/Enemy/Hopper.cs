using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hopper : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    EnemyDamage ED;

    private bool canMove;

    private int Dirx;
    private int Diry;

    Animator ani;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        ED = GetComponent<EnemyDamage>();
        ani = GetComponent<Animator>();
        Invoke("Stop", 0.1f);
    }

    void FixedUpdate()
    {
        if(ED.HP > 0)
        {
            if(canMove)
            {
                if(Dirx != 0 && Diry != 0)
                {
                    moveSpeed = 2 * 1.4142135623731f;
                }
                else
                {
                    moveSpeed = 4;
                }
                transform.position += new Vector3(Dirx,Diry) * moveSpeed * Time.deltaTime;
            }
        }
            
    }

    private void Stop()
    {
        ani.SetBool("isStart",true);
        Invoke("Move",0.4162f); 
    }


    private void Move()
    {
        Dirx = Random.Range(-1,1);
        Diry = Random.Range(-1,1);
        if(Dirx == 0 && Diry == 0)
        {
            int random = Random.Range(0, 3);
            if(random == 0)
                Dirx = 1;
            else if(random == 1)
                Dirx = -1;
            else if(random == 2)
                Diry = 1;
            else
                Diry = -1;
        }
        if(transform.position.x <= -5.4)
            Dirx = 1;
        if(transform.position.x >= 5.4)
            Dirx = -1;
        if(transform.position.y <= -2.4)
            Diry = 1;
        if(transform.position.y >= 2.4)
            Diry = -1;
        canMove = true;
        Invoke("Delay", 0.4998f);
    }

    private void Delay()
    {
        canMove = false;
        Invoke("Stop",0.3332f);
    }








}
