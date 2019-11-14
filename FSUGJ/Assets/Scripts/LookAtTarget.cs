using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target.transform.position);
        Vector3 tempTarget = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);


        //Vector3 relativePos = target.transform.position - transform.position;
        Vector3 relativePos = tempTarget - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
