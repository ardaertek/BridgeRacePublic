using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private Collider[] _canCollectableObjects;
    [SerializeField] float _sightRange;
    [SerializeField] private LayerMask Layer;
    float Dis1, Dis2;
    GameObject mostClose;
    PlayerBag _inventory;
    NavMeshAgent nav;
    private void Start()
    {
        _inventory = GetComponentInChildren<PlayerBag>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _canCollectableObjects = Physics.OverlapSphere(transform.position, _sightRange, Layer);
        if (_canCollectableObjects.Length != 0 && _inventory.ItemList.Count > 5 || _inventory.ItemList.Count < 17)
        {
            Dis1 = Vector3.Distance(_canCollectableObjects[0].transform.position, transform.position);
            mostClose = _canCollectableObjects[0].transform.gameObject;
            goTarget(selectItem());
        }
    }

    private GameObject selectItem()
    {
        for (int i = 0; i < _canCollectableObjects.Length; i++)
        {
            Dis2 = Vector3.Distance(_canCollectableObjects[i].transform.position, transform.position);
            if (Dis2 < Dis1)
            {
                mostClose = _canCollectableObjects[i].transform.gameObject;
                Dis1 = Dis2;
            }
        }
        return mostClose;
    }

    private void goTarget(GameObject obj)
    {
        nav.SetDestination(obj.transform.position);
    }
}
