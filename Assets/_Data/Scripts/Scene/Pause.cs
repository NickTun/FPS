using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject JumpB, GoB, pauseoff, pauseon;
    public Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }
    public void Pausa()
    {
        StartCoroutine("Paussa");
    }
    public void desPausa()
    {
        pauseoff.SetActive(false);
        pauseon.SetActive(true);
        Time.timeScale = 1f;
    }
    private IEnumerator Paussa()
    {
        anim.Play("PauseOn");
        yield return new WaitForSeconds(0.26f);
        Time.timeScale = 0.0001f;
        pauseoff.SetActive(true);
        pauseon.SetActive(false);
    }
}
