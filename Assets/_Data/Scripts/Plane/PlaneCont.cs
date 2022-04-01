using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCont : MonoBehaviour
{
    float random;
    float random1;
    public GameObject me, menues, menuobjects, planedestroy, speed;
    // Start is called before the first frame update
    void Start()
    {
        if(me.gameObject.name != "Plane")
        {
            random1 = Random.Range(0, 0.15f);
            random = Random.Range(-0.24f, 0);
            transform.Translate(random, random1, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (me.gameObject.name != "Plane")
        {
            if (menues.activeSelf == false)
            {
                transform.Translate(-0.0023f - speed.transform.position.x, 0, 0);
            }
            if (transform.position.x < -0.54f)
            {
                Object.Destroy(me);
            }
            if (menuobjects.activeSelf == true)
            {
                Object.Destroy(me);
            }
            if (planedestroy.activeSelf == true)
            {
                Object.Destroy(me);
            }
            if (me.transform.position.x < -0.2f)
            {
                me.name = "backplane";
            }
        }
    }
}
