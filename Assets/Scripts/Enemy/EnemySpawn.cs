using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject SpawnMob;

    GameManager gm;
    Map map;
    Map tmp;


    Animator ani;

    public bool cancall = false;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //if (gm.curRoom != null )
        //{
        //    map = GameObject.Find(gm.curRoom).GetComponent<Map>();
        //}
        //if (map != null )
        //{
        //    tmp = map;
        //}
        GetComponent<SpriteRenderer>().enabled = false;
        ani = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    if(map == null && cancall)
    //    {
    //        Debug.Log(gm.curRoom);
    //        map = GameObject.Find(gm.curRoom).GetComponent<Map>();
    //        tmp = map;
    //    }
    //    if(tmp != map)
    //    {
    //        map = GameObject.Find(gm.curRoom).GetComponent<Map>();
    //        tmp = map;
    //    }
    //}


    public void dospawn()
    {
        map = GameObject.Find(gm.curRoom).GetComponent<Map>();
        map.curEnemyCount++;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        ani.SetBool("Start",true);
        yield return new WaitForSeconds(0.2499f);
        GameObject Enemy = Instantiate(SpawnMob);
        Enemy.transform.position = transform.position;
        yield return new WaitForSeconds(0.4988f);
        Destroy(this.gameObject);
    }






}
