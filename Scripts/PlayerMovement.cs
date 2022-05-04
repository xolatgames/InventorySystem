using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navmesh;

    private void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();

        InventoryCore.ptrans.Add(transform);
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

    private void OnDestroy()
    {
        InventoryCore.ptrans.Remove(transform);
    }
}
