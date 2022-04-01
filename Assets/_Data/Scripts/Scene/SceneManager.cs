using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class SceneManager : MonoBehaviour, IUnityAdsListener
{
    public GameObject player, GameObjects, MenuObjects, buttons, plane, move, fplane1, fplane2, planedestroy, speed, replane, tutorial, pausebutton;
    private AudioSource Fail;
    private Animator anim;
    int a, b, c;
    float random1;
    string gameId = "4003025";
    string mySurfacingId = "rewardedVideo";
    bool testMode = false;
    void Start()
    {
        buttons.SetActive(false);
        anim = GetComponentInChildren<Animator>();
        a = 1;
        b = 0;
        c = 1;
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        Fail = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.touchCount >= 1 || Input.GetKey(KeyCode.Space))
        {
            if (MenuObjects.activeSelf == true)
            {
                StartCoroutine("enter");
            }
        }
        if (player.transform.position.y <= -0.6f)
        {
            StartCoroutine("exit");
            anim.Play("Menubegin");
        }
        if (b == 1)
        {
            if (a == 1)
            {
                StartCoroutine("start");
            }
        }
    }
    private IEnumerator start()
    {
        a = 0;
        Instantiate(plane);
        if (speed.transform.position.x * 650 >= 3.7f)
        {
            yield return new WaitForSeconds(0.9f);
        }
        else
        {
            yield return new WaitForSeconds(4.6f - speed.transform.position.x * 650);
        }
        a = 1;
    }
    private IEnumerator exit()
    {
        b = 0;
        if(c == 1)
        {
            Fail.Play();
        }
        c = 0;
        buttons.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        GameObjects.SetActive(false);
        player.SetActive(false);
        player.transform.position = new Vector3(0, 0.632f, 2.127559f);
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        player.SetActive(true);
    }
    public void restart()
    {
        Debug.Log("Pressed");
        if (Advertisement.IsReady(mySurfacingId))
        {
            Debug.Log("Ads");
            Advertisement.Show(mySurfacingId);
            c = 1;
        }
    }
    public void OnUnityAdsDidFinish(string mySurfacingId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            anim.Play("Menuexit");
            tutorial.transform.position = new Vector3(tutorial.transform.position.x, tutorial.transform.position.y, -20);
            GameObjects.SetActive(true);
            pausebutton.SetActive(true);
            buttons.SetActive(false);
            replane = GameObject.Find("Plane(Clone)");
            player.transform.position = new Vector3(replane.transform.position.x, replane.transform.position.y + 0.07f, replane.transform.position.z);
            b = 1;
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Skip");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("Error");
        }
    }
    private IEnumerator enter()
    {
        speed.transform.position = new Vector3(0, 0, 0);
        move.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        MenuObjects.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        tutorial.transform.position = new Vector3(tutorial.transform.position.x, tutorial.transform.position.y, 0);
        GameObjects.SetActive(true);
        pausebutton.SetActive(true);
        fplane1.SetActive(true);
        fplane2.SetActive(true);
        random1 = Random.Range(0, 0.03f);
        fplane1.transform.Translate(0, random1, 0);
        random1 = Random.Range(0, 0.03f);
        fplane2.transform.Translate(0, random1, 0);
        yield return new WaitForSeconds(0.3f);
        move.SetActive(false);
        b = 1;
        c = 1;
    }
    public void ExitToMenu()
    {
        anim.Play("Menuexit");
        StartCoroutine("EhitToMenu");
        buttons.SetActive(false);
    }
    private IEnumerator EhitToMenu()
    {
        move.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        MenuObjects.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        GameObjects.SetActive(false);
        pausebutton.SetActive(false);
        fplane1.transform.position = new Vector3(0.01155075f, -0.4658103f, 0);
        fplane2.transform.position = new Vector3(0.404f, -0.4658103f, 0);
        yield return new WaitForSeconds(0.3f);
        move.SetActive(false);
        fplane1.SetActive(false);
        fplane2.SetActive(false);
        b = 0;
        c = 1;
    }
    public void rebegin()
    {
        anim.Play("Menuexit");
        StartCoroutine("rebegini");
    }
    private IEnumerator rebegini()
    {
        speed.transform.position = new Vector3(0, 0, 0);
        tutorial.transform.position = new Vector3(tutorial.transform.position.x, tutorial.transform.position.y, 0);
        GameObjects.SetActive(true);
        pausebutton.SetActive(true);
        planedestroy.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        planedestroy.SetActive(false);
        buttons.SetActive(false);
        fplane1.SetActive(true);
        fplane2.SetActive(true);
        b = 1;
        c = 1;
    }
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}

