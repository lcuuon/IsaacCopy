using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    EnemySpawn[] spawn;
    GameManager gm;
    Door[] door;
    [SerializeField] GameObject open;

    private bool canspawn;
    private bool canClear = false;

    public int curEnemyCount;


    void Start()
    {

        door = GetComponentsInChildren<Door>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawn = GetComponentsInChildren<EnemySpawn>();
        Invoke("Canclear", 3f);
        canspawn= true;
    }

    void Canclear()
    {
        canClear= true;
    }

    void Update()
    {
        if (canspawn && this.gameObject.name == gm.curRoom)
        {
            canspawn = false;
            for(int i = 0 ;i < spawn.Length ;i++)
            {
                spawn[i].dospawn();
            }
            for(int i = 0 ;i < door.Length ;i++)
            {
                door[i].isopen = true;
                door[i].t = 0;
            }
        }

        if (canClear && curEnemyCount == 0)
        {
            Invoke("DoorOpen", 1);
        }
    }

    void DoorOpen()
    {
        for(int i = 0 ;i < door.Length ;i++)
        {
            open.SetActive(false);
            door[i].t = 0;

            door[i].isopen = false;
        }
    }
}
