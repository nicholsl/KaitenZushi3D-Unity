using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private Camera camera;
    //public bool selected;
    //public bool beltselected;
    private Vector3 position;
    private Vector2 startPos;

    GameObject hitobject;
    private float width;
    private float height;
    Plane dragplane;
    Vector3 mO;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        Ray ray;

        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            Vector3 pos = touch.position;
            Ray ray = camera.ScreenPointToRay(pos);
            float rayDistance;

            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;


                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        hitobject = raycastHit.collider.gameObject;
                        if (hitobject.GetComponent("Tray") || hitobject.GetComponent("Plate") || hitobject.GetComponent("Table"))
                        {
                            if (hitobject.GetComponent("Tray"))
                            {
                                hitobject.GetComponent<Tray>().selected = true;
                            }
                            else if (hitobject.GetComponent("Table"))
                            {
                                hitobject.GetComponent<Table>().selected = true;
                            }
                            else if (hitobject.GetComponent("Plate"))
                            {
                                dragplane = new Plane(new Vector3(0, 1f, 0), hitobject.transform.position);
                                hitobject.GetComponent<Plate>().onTray = true;

                                hitobject.GetComponent<Plate>().selected = true;
                                dragplane.Raycast(ray, out rayDistance);
                                mO = hitobject.transform.position - ray.GetPoint(rayDistance);

                            }

                            var outline = raycastHit.collider.gameObject.AddComponent<Outline>();

                            outline.OutlineMode = Outline.Mode.OutlineAll;
                            outline.OutlineColor = Color.green;
                            outline.OutlineWidth = 10f;
                        }
                        else if (hitobject.GetComponent("conveyorbelt"))
                        {
                            conveyorbelt[] belts = FindObjectsOfType<conveyorbelt>();
                            if (belts != null)
                            {
                                for (int i = 0; i < belts.Length; i++)
                                {
                                    Debug.Log(belts.Length);
                                    conveyorbelt belt = belts[i];
                                    belt.GetComponent<conveyorbelt>().selected = true;

                                    var outline = belt.gameObject.AddComponent<Outline>();

                                    outline.OutlineMode = Outline.Mode.OutlineAll;
                                    outline.OutlineColor = Color.green;
                                    outline.OutlineWidth = 10f;

                                    Debug.Log("conveyor hit!");
                                }
                            }

                        }

                        Debug.Log("hit!");



                    }
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    Ray mRay = Camera.main.ScreenPointToRay(touch.position);

                    //if ()
                    if (hitobject.GetComponent("Plate"))
                    {
                        if (dragplane.Raycast(mRay, out rayDistance))
                            hitobject.transform.position = mRay.GetPoint(rayDistance) + mO;

                        hitobject.transform.Translate(0, 1.5f, 0);

                        //direction = touch.position - startPos;

                        //Vector2 vecpos = touch.position;
                        //vecpos.x = (vecpos.x - width) / width;
                        //vecpos.y = (vecpos.y - height) / height;
                        //position = new Vector3(-vecpos.x, vecpos.y, 0.0f);

                        ////// Position the cube.
                        //hitobject.transform.root.position = position;
                    }
                        break;

                case TouchPhase.Ended:
                    if (hitobject.GetComponent("Tray") || hitobject.GetComponent("Plate") || hitobject.GetComponent("Table"))
                    {
                        if (hitobject.GetComponent("Tray"))
                        {
                            hitobject.GetComponent<Tray>().selected = false;
                        }
                        else if (hitobject.GetComponent("Table"))
                        {
                            hitobject.GetComponent<Table>().selected = false;
                        }
                        else if (hitobject.GetComponent("Plate"))
                        {
                            hitobject.GetComponent<Plate>().selected = false;
                        }

                        Destroy(hitobject.GetComponent<Outline>());

                    }
                    else if (hitobject.GetComponent("conveyorbelt"))
                    {
                        conveyorbelt[] belts = FindObjectsOfType<conveyorbelt>();
                        if (belts != null)
                        {
                            for (int i = 0; i < belts.Length; i++)
                            {
                                conveyorbelt belt = belts[i];
                                belt.GetComponent<conveyorbelt>().selected = false;

                                Destroy(belt.gameObject.GetComponent<Outline>());
                            }
                        }
                    }
                    // Report that the touch has ended when it ends

                    break;
            }

            //if (Physics.Raycast(ray, out RaycastHit raycastHit))
            //{
            //    Debug.Log("hit!");

            //    var outline = raycastHit.collider.gameObject.AddComponent<Outline>();

            //    outline.OutlineMode = Outline.Mode.OutlineAll;
            //    outline.OutlineColor = Color.green;
            //    outline.OutlineWidth = 10f;

              
            //}

            //RaycastHit hit;
          
        }

    }
}
