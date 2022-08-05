using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMaker : MonoBehaviour
{
    [SerializeField] GameObject rayPos;
    Ray ray;
    RaycastHit hit;
    public LayerMask layer;
    private void LateUpdate()
    {
        if (Physics.Raycast(rayPos.transform.position, rayPos.transform.forward, out hit, 5f, layer))
        {
            MakeBridge(hit.transform.gameObject);
        }
    }

    public void MakeBridge(GameObject obj)
    {
        obj.GetComponent<CollectableItemScript>().OffObstacleCollider();
        obj.GetComponent<MeshRenderer>().enabled = true;
    }
}
