using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Animator headAni;
    [SerializeField] Animator bodyAni;
    [SerializeField] SpriteRenderer bodyRenderer;
    [SerializeField] GameObject bulletPrefeb;

    private bool isHo;
    private bool isVer;
    private bool cooldown = true;

    Rigidbody2D rb;

    private float DirH;
    private float DirV;
    private float bulletoffsetx = 0.31f;
    private float bulletoffsety = 0.34f;


    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        aniControl();
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (cooldown)
                bulletFire();
        }
        
    }

    private void FixedUpdate() 
    {
        if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0) 
        {
            moveSpeed = 4 * 1.4142135623731f;
        } else {
            moveSpeed = 8;
        }

        DirH = Input.GetAxis("Horizontal") * moveSpeed;
        DirV = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector2(DirH, DirV);    
    }

    private void bulletFire()
    {
        headAni.SetBool("isattack", true);

        cooldown = false;
        GameObject bullet = Instantiate(bulletPrefeb);
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();

        if (bulletoffsetx == 0.31f)
        {
            bulletoffsetx = -0.12f;
        }
        else if (bulletoffsetx == -0.12f)
        {
            bulletoffsetx = 0.31f;
        }
        if (bulletoffsety == 0.34f)
        {
            bulletoffsety = 0.59f;
        }
        else if (bulletoffsety == 0.59f)
        {
            bulletoffsety = 0.34f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            bullet.transform.position = transform.position + new Vector3(bulletoffsetx, 0);
            bulletrb.velocity = new Vector2(0, 8);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            bullet.transform.position = transform.position + new Vector3(bulletoffsetx, 0);
            bulletrb.velocity = new Vector2(0, -8);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            bullet.transform.position = transform.position + new Vector3(0, bulletoffsety);
            bulletrb.velocity = new Vector2(-8, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            bullet.transform.position = transform.position + new Vector3(0, bulletoffsety);
            bulletrb.velocity = new Vector2(8, 0);
        }
        StartCoroutine(AttackCoolDown());
    }

    IEnumerator AttackCoolDown()
    {
        
        yield return new WaitForSeconds(0.4f);
        headAni.SetBool("isattack", false);
        cooldown = true;
        
    }

    private void aniControl()
    {
        if(Input.GetAxis("Horizontal") != 0 && rb.velocity.y == 0)
        {
            isHo = true;
            isVer = false;
            bodyAni.SetBool("moveHo",true);
        }

        if(Input.GetAxis("Vertical") != 0 && rb.velocity.x == 0)
        {
            isVer = true;
            isHo = false;
            bodyAni.SetBool("moveVer",true);
        }

        if(rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            isHo = false;
            isVer = false;

            bodyAni.SetBool("moveVer",false);
            bodyAni.SetBool("moveHo",false);

            headAni.SetBool("isfront",true);
            headAni.SetBool("isright",false);
            headAni.SetBool("isback",false);
            headAni.SetBool("isleft",false);
        }

        if(rb.velocity.x > 0 && isHo)
        {
            headAni.SetBool("isright",true);
            headAni.SetBool("isfront",false);
            headAni.SetBool("isback",false);
            headAni.SetBool("isleft",false);

            bodyRenderer.flipX = false;
        }
        else if(rb.velocity.x < 0 && isHo)
        {
            headAni.SetBool("isleft",true);
            headAni.SetBool("isfront",false);
            headAni.SetBool("isback",false);
            headAni.SetBool("isright",false);

            bodyRenderer.flipX = true;
        }

        if(rb.velocity.y > 0 && isVer)
        {
            headAni.SetBool("isback",true);
            headAni.SetBool("isright",false);
            headAni.SetBool("isfront",false);
            headAni.SetBool("isleft",false);
        }
        else if(rb.velocity.y < 0 && isVer)
        {
            headAni.SetBool("isfront",true);
            headAni.SetBool("isright",false);
            headAni.SetBool("isback",false);
            headAni.SetBool("isleft",false);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            headAni.SetBool("isback",true);
            headAni.SetBool("isright",false);
            headAni.SetBool("isfront",false);
            headAni.SetBool("isleft",false);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            headAni.SetBool("isfront",true);
            headAni.SetBool("isright",false);
            headAni.SetBool("isback",false);
            headAni.SetBool("isleft",false);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            headAni.SetBool("isleft",true);
            headAni.SetBool("isfront",false);
            headAni.SetBool("isback",false);
            headAni.SetBool("isright",false);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            headAni.SetBool("isright",true);
            headAni.SetBool("isfront",false);
            headAni.SetBool("isback",false);
            headAni.SetBool("isleft",false);
        }
    }
}
