using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlane : MonoBehaviour
{
    float random;
    float random1, x, y, z;
    public GameObject me, menues, planedestroy;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (menues.activeSelf == false)
        {
            transform.Translate(-0.0023f, 0, 0);
        }
        if (transform.position.x < -0.54f)
        {
            me.transform.position = new Vector3(x, y, z);
            me.SetActive(false);
        }
        if (planedestroy.activeSelf == true)
        {
            me.transform.position = new Vector3(x, y, z);
            me.SetActive(false);
        }
    }
}
