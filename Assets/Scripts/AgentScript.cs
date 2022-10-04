using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform targetTransform;
    [SerializeField] Transform [] baseTransforms;
    [SerializeField] float arrivingDistance;
    public bool chaseModeOn = false;
    int baseIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chaseModeOn)
        {
            agent.destination = targetTransform.position;
            if (agent.remainingDistance < arrivingDistance && !agent.pathPending)
            {
                Debug.Log("Stopped");
            }
        }
        else
        {
            if (agent.remainingDistance < arrivingDistance && !agent.pathPending)
            {
                baseIndex++;
                if (baseIndex >= baseTransforms.Length)
                {
                    baseIndex = 0;
                }
                agent.destination = baseTransforms[baseIndex].position;
            }
        }

        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chaseModeOn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chaseModeOn = false;
        }
    }




}
