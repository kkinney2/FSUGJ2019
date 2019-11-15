using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject prefab_Character;
    public GameObject[] characters;
    public int numOfCharacters = 5;
    GameObject[] taskLocations;

    // Start is called before the first frame update
    void Start()
    {
        taskLocations = GameObject.FindGameObjectsWithTag("Task_Location");

        for (int i = 0; i < numOfCharacters; i++)
        {
            //GameObject a_Character = Instantiate(prefab_Character);
            GameObject a_Character = Instantiate(characters[Random.Range(0, characters.Length-1)]);
            a_Character.transform.position = taskLocations[Random.Range(0, taskLocations.Length - 1)].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
