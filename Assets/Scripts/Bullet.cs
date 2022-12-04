using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Animator ani;

    IEnumerator AutoDestroy()
    {
        ani = GetComponent<Animator>();
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(AutoDestroy());
        ani.SetBool("isboom", true);
    }
}
