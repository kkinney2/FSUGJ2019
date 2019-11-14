using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmSwitch : MonoBehaviour
{
    public bool is2D;

    //public Switchable realm_2D;
    //public Switchable realm_3D;

    public GameObject realm_2D;
    public GameObject realm_3D;

    public float switchDelay = 0.5f;

    public bool isSwitchingRealms = false;

    // Start is called before the first frame update
    void Start()
    {
        realm_2D.gameObject.SetActive(true);
        realm_3D.gameObject.SetActive(false);

        is2D = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && !isSwitchingRealms)
        {
            StartCoroutine(SwitchRealms());
        }
    }

    IEnumerator SwitchRealms()
    {
        isSwitchingRealms = true;

        //realm_2D.shouldSwitch = true;
        //realm_3D.shouldSwitch = true;

        float numSwitches = 0;
        //while (numSwitches <= 10)
        while (numSwitches < 1)
        {
            if (realm_3D.activeSelf == false)
            {
                realm_3D.SetActive(true);
            }
            else
            {
                realm_3D.SetActive(false);
            }
            
            yield return new WaitForSeconds(switchDelay);

            numSwitches++;
        }

        if (is2D)
        {
            realm_3D.gameObject.SetActive(true);

            is2D = false;
        }
        else
        {
            realm_3D.gameObject.SetActive(false);

            is2D = true;
        }
        

        isSwitchingRealms = false;
    }
}
