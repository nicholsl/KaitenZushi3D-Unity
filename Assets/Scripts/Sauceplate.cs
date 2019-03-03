using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauceplate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (transform && transform.parent)
        {
            transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), Time.deltaTime * 60f);
        }


    }
}
