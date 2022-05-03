using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    public static Transform ptrans;

    private NavMeshAgent navmesh;

    private void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();

        ptrans = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !InventoryCore.showed)
        {
            SetDestinationToMousePosition();
        }
    }

    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            navmesh.SetDestination(hit.point);
        }
    }
}
