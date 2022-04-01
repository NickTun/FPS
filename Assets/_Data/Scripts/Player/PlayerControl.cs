using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public AudioSource Jump, Land;
    float pspeed = -0.0023f;
    public GameObject ButGo, ButJump, speed;
    public ParticleSystem particle;
    int go, vibr;
    int ground = 0;
    private Rigidbody2D rb;
    private Animator anim;
    float timeforjump;
    float jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        GetComponentsInParent<AudioSource>();
    }

    void FixedUpdate()
    {
        StartCoroutine("timejump");
        if(ground == 1)
        {
            transform.Translate(pspeed - speed.transform.position.x, 0, 0);
            particle.Stop();
        }
        else
        {
            particle.Play();
        }
        rb.velocity = new Vector2(0.7f * go, rb.velocity.y);
    }
    private IEnumerator timejump()
    {
        yield return new WaitForSeconds(0.05f);
        timeforjump++;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        go = 0;
        ButGo.SetActive(false);
        ButJump.SetActive(true);
        ground = 1;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        vibr = 0;
        ButGo.SetActive(true);
        ButJump.SetActive(false);
        ground = 0;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Land.Play();
    }
    public void tap()
    {
        anim.Play("Jump");
        jump = 0;
        timeforjump = 0;
    }
    public void oftap()
    {
        Jump.Play();
        jump = timeforjump;
        if(ground == 1)
        {
            anim.Play("JumpNowIdle");
            if (jump >= 55)
            {
                rb.AddForce(transform.up * (55 * 0.05f), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(transform.up * (jump * 0.05f), ForceMode2D.Impulse);
            }
        }
    }
    public void goOn()
    {
        go = 1;
    }
    public void goOff()
    {
        go = 0;
    }
}
