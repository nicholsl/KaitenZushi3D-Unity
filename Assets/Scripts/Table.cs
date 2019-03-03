using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public int tablecount;
    public int waittime;
    public List<GameObject> colliders;

    public bool selected;
    //private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        tablecount = 0;
        waittime = 15;
        //outline = new Outline();
        //outline.OutlineMode = Outline.Mode.OutlineAll;
        //outline.OutlineColor = Color.green;
        //outline.OutlineWidth = 10f;
        //outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int count = colliders.Count;
        int currenttable = 0;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (colliders[i] != null)
                {
                    currenttable += 1;
                }
            }
            tablecount = currenttable;
        }

    }
   
    //private void TableDestroy(GameObject obj, int time)
    //{
    //    Destroy(obj, 10);
    //    tablecount -= 1;

    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (tablecount >= 4)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            tablecount += 1;
            colliders.Add(collision.gameObject);
            Destroy(collision.gameObject, waittime);
        }
    }

}
