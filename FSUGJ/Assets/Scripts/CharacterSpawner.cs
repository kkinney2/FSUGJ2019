using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject prefab_Character;
    public int numOfCharacters = 5;
    GameObject[] taskLocations;
   
    // Start is called before the first frame update
    void Start()
    {
        taskLocations = GameObject.FindGameObjectsWithTag("Task_Location");

        for (int i = 0; i < numOfCharacters; i++)
        {
            Instantiate(prefab_Character);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
