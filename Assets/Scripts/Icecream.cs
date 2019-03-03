using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecream : MonoBehaviour
{
    //public Transform target;
    Quaternion m_MyQuaternion;
    //float m_Speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
       m_MyQuaternion = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
        transform.RotateAround(transform.parent.position, new Vector3(1,0,0), Time.deltaTime * 30f);

        Vector3 relativePos = transform.parent.position - transform.position;
        transform.rotation = m_MyQuaternion * transform.rotation;
        //transform.rotation = Quaternion.FromToRotation(Vector3.up,m_MyQuaternion)

        //Vector3 v = transform.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(v.x,target.transform.rotation.eulerAngles.y, v.z);

    }
}
