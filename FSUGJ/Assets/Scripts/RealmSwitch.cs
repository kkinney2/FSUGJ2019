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

    Character[] all_Characters;

    public float switchDelay = 0.5f;
    public float duration_3DRealm = 0.5f;

    public bool isSwitchingRealms = false;
    public bool realmSwitchToggle = false;

    // Start is called before the first frame update
    void Start()
    {
        if (is2D)
        {
            realm_2D.gameObject.SetActive(true);
            realm_3D.gameObject.SetActive(false);
        }
        else
        {
            realm_2D.gameObject.SetActive(false);
            realm_3D.gameObject.SetActive(true);
        }

        all_Characters = UnityEngine.Object.FindObjectsOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && !isSwitchingRealms)
        {
            all_Characters = UnityEngine.Object.FindObjectsOfType<Character>();
            if (realmSwitchToggle)
            {
                StartCoroutine(SwitchRealms());
            }
            else
            {
                StartCoroutine(Temp3DRealm());
            }
        }
    }

    void SwitchCharacters()
    {
        foreach (Character a_Character in all_Characters)
        {
            if (a_Character.is2D == true)
            {
                a_Character.is2D = false;
            }
            else
            {
                a_Character.is2D = true;
            }
        }
    }

    IEnumerator Temp3DRealm()
    {
        isSwitchingRealms = true;

        SwitchCharacters();
        realm_2D.SetActive(false);
        realm_3D.SetActive(true);

        // TODO: Insert TV static here
        #region Test Flicker
        /*
        yield return new WaitForSeconds(duration_3DRealm / 3f);

        SwitchCharacters();
        realm_2D.SetActive(true);
        realm_3D.SetActive(false);

        yield return new WaitForSeconds(duration_3DRealm / 3f);

        SwitchCharacters();

        realm_2D.SetActive(false);
        realm_3D.SetActive(true);

        */
        #endregion
        yield return new WaitForSeconds(duration_3DRealm);

        SwitchCharacters();
        realm_2D.SetActive(true);
        realm_3D.SetActive(false);

        isSwitchingRealms = false;
    }

    IEnumerator SwitchRealms()
    {
        isSwitchingRealms = true;

        //realm_2D.shouldSwitch = true;
        //realm_3D.shouldSwitch = true;

        float numSwitches = 0;
        //while (numSwitches <= 10)
        SwitchCharacters();
        while (numSwitches < 1)
        {
            if (realm_3D.activeSelf == false)
            {
                realm_2D.SetActive(false);
                realm_3D.SetActive(true);
            }
            else
            {
                realm_2D.SetActive(true);
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
