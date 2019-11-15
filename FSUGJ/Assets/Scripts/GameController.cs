using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 3)]
    public int difficulty = 1;

    public CharacterSpawner spawner;
    public RealmSwitch switcher;

    float d_Time = 0;
    float timeTillSwitch = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
