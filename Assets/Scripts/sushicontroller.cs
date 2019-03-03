using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sushicontroller : MonoBehaviour
{
    public int sushicount;       // Reference to the player's heatlh.
    public GameObject dish;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform spawnPoint;         // An array of the spawn points th
    public GameObject[] dishes;
    public List<GameObject> activePlates;
    public GameObject oldestPlate;


    public int dishtospawn;
    public int dishcounter;

    //public GameObject gameStartPanel;
    //public Text gameStartText;

    //void Awake() {
    //    gameStartPanel.SetActive(true);
    //    gameStartText.text = "Serve the sushi!";

    //}

    void Start()
    {
        dishcounter = 0;
        sushicount = 0;
        //activePlates = new List<GameObject>();
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        
    }

    public List<GameObject> GetActivePlates()
    {
        //Debug.Log("getactiveplates called");
        return activePlates;
    }

    public GameObject GetOldestPlate()
    {
        //Debug.Log("oldestplatecalled");
        return oldestPlate;
    }
    public void SetOldestPlate()
    {
        if (activePlates.Count >= 1)
        {
            oldestPlate = activePlates[activePlates.Count - 1];
        }
        else
        {
            oldestPlate = null;
        }
    }

    void Spawn()
    {
        sushicount += 1;

        // Find a random index between zero and one less than the number of spawn points.

        dishtospawn = dishcounter % 3;

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject newdish = Instantiate(dishes[dishtospawn], spawnPoint.position, spawnPoint.rotation);
        if (activePlates.Count == 0)
        {
            activePlates.Insert(0, newdish);
            SetOldestPlate();
        }
        else
        {
            activePlates.Insert(0, newdish);
        }

        dishcounter += 1; 
    }

    private void Update()
    {

    }
}
