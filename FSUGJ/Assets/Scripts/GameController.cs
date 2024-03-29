﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 3)]
    public int difficulty = 1;
    public bool isPlaying = true;

    public CharacterSpawner spawner;
    public RealmSwitch switcher;

    public Transform winRoom;
    public Transform loseRoom;
    public GameObject player;

    float d_Time = 0;
    float timeTillSwitch = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeltaUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            Application.Quit();
        }

    }

    IEnumerator DeltaUpdate()
    {
        while (isPlaying)
        {
            yield return new WaitForEndOfFrame();
            if (d_Time > timeTillSwitch)
            {
                switcher.Switch_Realms();
                d_Time = 0f;
                timeTillSwitch = Random.Range(3, 10f);
            }
            else
            {
                if (!switcher.isSwitchingRealms)
                {
                    d_Time += Time.deltaTime;
                }
            }
        }
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(10f);
        LoadScene tempLoad = new LoadScene();
        tempLoad.Load(0);
    }

    public bool CompareWithTheOne(GameObject a_Character)
    {
        if (a_Character.GetComponent<Character>().isTheOne)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void WinState()
    {
        Debug.Log("You Found the ONE");
        player.transform.position = winRoom.position;
        isPlaying = false;
        StartCoroutine(RestartGame());
    }

    public void LoseState()
    {
        Debug.Log("WRONG");
        player.transform.position = loseRoom.position;
        isPlaying = false;
        StartCoroutine(RestartGame());
    }
}
