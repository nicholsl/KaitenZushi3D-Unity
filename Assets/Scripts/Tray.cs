using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{

    public bool selected;
    //private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        //outline = new Outline();
        //outline.OutlineMode = Outline.Mode.OutlineAll;
        //outline.OutlineColor = Color.green;
        //outline.OutlineWidth = 10f;
        //outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Plate>().onTray = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<Plate>().onTray = false;
    }
}
