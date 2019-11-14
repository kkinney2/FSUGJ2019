using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    public GameObject objectToSwitchWith;

    public bool shouldSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        //objectToSwitchWith.gameObject.SetActive(false);
        //StartCoroutine(Switching());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (shouldSwitch)
        {
            objectToSwitchWith.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        */
    }

    IEnumerator Switching()
    {
        while (true)
        {
            if (shouldSwitch)
            {
                objectToSwitchWith.gameObject.SetActive(true);
                gameObject.SetActive(false);
                yield return new WaitForSeconds(1 / 60);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
