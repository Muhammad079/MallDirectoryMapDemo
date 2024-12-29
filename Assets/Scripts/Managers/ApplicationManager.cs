using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ApplicationManager : MonoBehaviour
{
    public List<ShopData> Destination = new List<ShopData>();
    public NavMeshAgent Agent;
    public MapScreen MapScreen;

    public static ApplicationManager Instance;
    public Vector3 initialPosition;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        MapScreen.InitializeUI(Destination);
    }

    [ContextMenu("SetDestination")]
    public void SetAgentDestination(Vector3 position)
    {
        Agent.GetComponent<AIPlayer>().ResetTrail();
        //Agent.transform.position = initialPosition;
        Agent.SetDestination(position);
    }
}
