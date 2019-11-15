using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    GameController gameController;

    public int difficulty = 1;
    public GameObject[] characters;
    GameObject[] temp_Characters;
    public GameObject[] numbers;
    GameObject[] temp_Numbers;
    public int numOfCharacters = 5;
    GameObject[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.spawner = this;
        difficulty = gameController.difficulty;

        spawnLocations = GameObject.FindGameObjectsWithTag("Spawn_Location");

        GameObject a_Character;
        GameObject a_Number;

        switch (difficulty)
        {
            case 1:
                #region All Characters (Ignoring numOfCharacters)

                int randomCharNum = Random.Range(0, characters.Length - 1);
                a_Character = Instantiate(characters[randomCharNum]);
                a_Character.transform.SetParent(this.transform);

                // Spawn the '1'
                a_Number = Instantiate(numbers[0]);

                // Attach Number
                a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
                a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

                a_Character.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].transform.position;

                #region Randomize Numbers Order
                temp_Numbers = new GameObject[numbers.Length - 1];
                Debug.Log("tempNums length: " + temp_Numbers.Length);
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    temp_Numbers[i] = numbers[i + 1];
                }

                numbers = temp_Numbers;
                #endregion
                int y = 0;
                for (int i = 0; i < characters.Length; i++)
                {
                    if (i == randomCharNum)
                    {
                        // Skip already spawned Character
                        //y--;
                        continue;
                    }
                    //GameObject a_Character = Instantiate(prefab_Character);
                    a_Character = Instantiate(characters[i]);
                    a_Character.transform.SetParent(this.transform);

                    // Spawn any other number besides the '1'
                    a_Number = Instantiate(numbers[y]);

                    // Attach Number
                    a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
                    a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

                    a_Character.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].transform.position;
                    y++;
                }
                #endregion
                break;

            case 2:
                #region Random Characters
                a_Character = Instantiate(characters[Random.Range(0, characters.Length - 1)]);
                a_Character.transform.SetParent(this.transform);

                // Spawn the '1'
                a_Number = Instantiate(numbers[0]);

                a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
                a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

                a_Character.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].transform.position;

                for (int i = 0; i < numOfCharacters - 1; i++)
                {
                    //GameObject a_Character = Instantiate(prefab_Character);
                    a_Character = Instantiate(characters[Random.Range(0, characters.Length - 1)]);
                    a_Character.transform.SetParent(this.transform);

                    // Spawn any other number besides the '1'
                    a_Number = Instantiate(numbers[Random.Range(1, numbers.Length - 1)]);

                    a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
                    a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

                    a_Character.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].transform.position;
                }
                #endregion
                break;
            case 3:
                #region Lots of Random Characters
                a_Character = Instantiate(characters[Random.Range(0, characters.Length - 1)]);
                a_Character.transform.SetParent(this.transform);

                // Spawn the '1'
                a_Number = Instantiate(numbers[0]);

                a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
                a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

                a_Character.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].transform.position;

                for (int i = 0; i < numOfCharacters * numOfCharacters; i++)
                {
                    //GameObject a_Character = Instantiate(prefab_Character);
                    a_Character = Instantiate(characters[Random.Range(0, characters.Length - 1)]);
                    a_Character.transform.SetParent(this.transform);

                    // Spawn any other number besides the '1'
                    a_Number = Instantiate(numbers[Random.Range(1, numbers.Length - 1)]);

                    a_Number.transform.position = a_Character.GetComponent<Character>().body_Num.transform.position;
                    a_Number.transform.SetParent(a_Character.GetComponent<Character>().body_Num.transform);

                    a_Character.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length - 1)].transform.position;
                }
                #endregion
                break;
            default:
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
