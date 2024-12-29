using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPlayer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private NavMeshAgent agent;
    private float positionThreshold = 0.5f;
    private Vector3 lastPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.positionCount = 0;

        lastPosition = transform.position;
        AddPoint(lastPosition);
    }

    void Update()
    {
        if (agent.hasPath && Vector3.Distance(transform.position, lastPosition) > positionThreshold)
        {
            lastPosition = transform.position;
            AddPoint(lastPosition);
        }
    }
    private void AddPoint(Vector3 position)
    {
        int currentPoints = lineRenderer.positionCount;
        lineRenderer.positionCount = currentPoints + 1;
        lineRenderer.SetPosition(currentPoints, position);
    }

    public void ResetTrail()
    {
        lineRenderer.positionCount = 0;
        lastPosition = transform.position;
        AddPoint(lastPosition);
    }
}
