using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject SpawnMob;

    Animator ani;

    

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        ani = GetComponent<Animator>();
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
