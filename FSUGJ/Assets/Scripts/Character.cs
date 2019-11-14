using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool hasTask = false;
    public float taskDuration;

    GameObject[] taskLocations;

    public GameObject body_2D;
    public GameObject body_Num;

    public bool is2D = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = new NavMeshAgent();
        }

        taskLocations = GameObject.FindGameObjectsWithTag("Task_Location");

        StartCoroutine(PerformTasks());
    }

    // Update is called once per frame
    void Update()
    {
        if (is2D)
        {
            body_2D.SetActive(true);
            body_Num.SetActive(false);
        }
        else
        {
            body_2D.SetActive(false);
            body_Num.SetActive(true);
        }
    }

    IEnumerator PerformTasks()
    {
        while (true)
        {
            if (!hasTask)
            {
                hasTask = true;
                taskDuration = Random.Range(1f, 10f);

                //Get random location
                Vector3 taskPos = taskLocations[Random.Range(0, taskLocations.Length - 1)].transform.position;

                // Go to location
                agent.destination = taskPos;


                //Wait at location until task is 'done'
                while (Vector3.Distance(transform.position, taskPos) >= 1f)
                {
                    Debug.Log("Dist to target: " + Vector3.Distance(transform.position, taskPos));
                    yield return new WaitForEndOfFrame();
                }

                yield return new WaitForSeconds(taskDuration);

                hasTask = false;
            }
            yield return new WaitForEndOfFrame();
        }

    }
}
