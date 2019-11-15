using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject prefab_Character;
    public GameObject[] characters;
    public GameObject[] numbers;
    public int numOfCharacters = 5;
    GameObject[] taskLocations;

    // Start is called before the first frame update
    void Start()
    {
        taskLocations = GameObject.FindGameObjectsWithTag("Task_Location");

        GameObject a_Character = Instantiate(characters[Random.Range(0, characters.Length - 1)]);
        a_Character.transform.SetParent(this.transform);

        // Spawn the '1'
        GameObject a_Number = Instantiate(numbers[0]);

        a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
        a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

        a_Character.transform.position = taskLocations[Random.Range(0, taskLocations.Length - 1)].transform.position;

        for (int i = 0; i < numOfCharacters-1; i++)
        {
            //GameObject a_Character = Instantiate(prefab_Character);
            a_Character = Instantiate(characters[Random.Range(0, characters.Length-1)]);
            a_Character.transform.SetParent(this.transform);

            // Spawn any other number besides the '1'
            a_Number = Instantiate(numbers[Random.Range(1, numbers.Length-1)]);

            a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
            a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

            a_Character.transform.position = taskLocations[Random.Range(0, taskLocations.Length - 1)].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
