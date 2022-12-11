using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage :MonoBehaviour
{
    [SerializeField] int HP;

    SpriteRenderer[] sr;

    [SerializeField] GameObject _blood;

    [SerializeField] GameObject dieEffect;

    Vector3 tempPos;

    void Start()
    {
        
        tempPos = transform.position;
        sr = GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(HP <= 0)
        {
            HP = 10;
            GameObject blood = Instantiate(_blood);
            GameObject die = Instantiate(dieEffect);
            blood.transform.position = transform.position - new Vector3(0,1);
            die.transform.position = transform.position;
            gameObject.SetActive(false);
            Invoke("Die",3f);
        }
    }

    void Die()
    {
        transform.position = tempPos;
        gameObject.SetActive(true);
    }

    void ColorRe()
    {
        sr[0].color = Color.white;
        sr[1].color = Color.white;
    }

    void canHit()
    {
        gameObject.layer = 6;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HP--;
            sr[0].color = new Color(1,124 / 255,124 / 255);
            sr[1].color = new Color(1,124 / 255,124 / 255);
            gameObject.layer = 10;
            Invoke("ColorRe",0.2f);
            Invoke("canHit",0.5f);

        }
    }

}
