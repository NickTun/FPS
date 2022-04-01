using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float random;
    float random1;
    private Animator anim;
    public GameObject particle;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        random1 = Random.Range(0, 0.15f);
        random = Random.Range(-0.24f, 0);
        transform.Translate(random, random1, 0);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine("get");
        }
    }
    private IEnumerator get()
    {
        anim.Play("Get");
        particle.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Object.Destroy(gameObject);
    }
}
