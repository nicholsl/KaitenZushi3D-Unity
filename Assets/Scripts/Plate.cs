using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject controller;

    public bool onTray;
    public bool selected;

    public float conveyorSpeed;

    private bool onSouth;
    private bool onWest;
    private bool onNorth;
    private bool onEast;
    //private Outline outline;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Sushi Manager");
        rb = GetComponent<Rigidbody>();
        onTray = false;
        selected = false;
        conveyorSpeed = 1f;

        //outline = new Outline(); 

        //outline.OutlineMode = Outline.Mode.OutlineAll;
        //outline.OutlineColor = Color.green;
        //outline.OutlineWidth = 10f;
        //outline.enabled = false;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onTray == false)
        {
            if (onSouth)
            {
                rb.transform.Translate(Vector3.left * conveyorSpeed * Time.deltaTime, Space.World);
            } else if (onWest)
            {
                rb.transform.Translate(Vector3.forward * conveyorSpeed * Time.deltaTime, Space.World);
            } else if (onNorth)
            {
                rb.transform.Translate(Vector3.right * conveyorSpeed * Time.deltaTime, Space.World);
            } else if (onEast)
            {
                rb.transform.Translate(Vector3.back * conveyorSpeed * Time.deltaTime, Space.World);
            }
        }
        else
        {
            onSouth = false;
            onWest = false;
            onNorth = false;
            onEast = false;
        }

    }
    private void PlateDestroy()
    {
        Debug.Log("PlateDestroy called");
        controller.GetComponent<sushicontroller>().activePlates.Remove(gameObject);
        controller.GetComponent<sushicontroller>().SetOldestPlate();

        //var pop = GetComponentInChildren<ParticleSystem>();
        //pop.Play();
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("South Belt") && !onWest && !onNorth && !onEast)
        {
            onSouth = true;
            onTray = false;
        }
        else if (collision.gameObject.CompareTag("West Belt") && !onSouth && !onNorth && !onEast)
        {
            onWest = true;
            onTray = false;
        }
        else if (collision.gameObject.CompareTag("North Belt") && !onWest && !onSouth && !onEast)
        {
            onNorth = true;
            onTray = false;
        }
        else if (collision.gameObject.CompareTag("East Belt") && !onWest && !onNorth && !onSouth)
        {
            onEast = true;
            onTray = false;
        }
        else if (collision.gameObject.CompareTag("Plate"))
        {
            PlateDestroy();
        }else if (collision.gameObject.CompareTag("Floor"))
        {
            PlateDestroy();
        }
        else if (collision.gameObject.CompareTag("Tray"))
        {
            onTray = true;
        }
        else if (collision.gameObject.CompareTag("Table"))
        {
            onTray = true;
        }
        else if (collision.gameObject.CompareTag("Expire"))
        {
            PlateDestroy();
        }
    }
}
