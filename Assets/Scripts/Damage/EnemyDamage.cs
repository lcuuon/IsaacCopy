using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int HP;
    
    [SerializeField] GameObject _blood;

    Animator ani;

    SpriteRenderer sr;

    GameManager gm;
    Map map;
    Map tmp;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        map = GameObject.Find(gm.curRoom).GetComponent<Map>();
        tmp = map;
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(tmp != map)
        {
            map = GameObject.Find(gm.curRoom).GetComponent<Map>();
            tmp = map;
        }

        if(HP == 0)
        {
            gameObject.layer = 10;
            map.curEnemyCount--;
            HP = -1;
            GameObject blood = Instantiate(_blood);
            blood.transform.position = transform.position - new Vector3(0, 1);
            ani.SetBool("isDie",true);
            Invoke("Die",0.6f);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    void ColorRe()
    {
        sr.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            HP--;
            sr.color = new Color(1, 124/255, 124/255);
            Invoke("ColorRe",0.2f);
        }
    }


}
