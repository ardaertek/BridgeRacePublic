using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject _nextSpawner;
    [SerializeField] private GameObject _previousSpawner;
    [SerializeField] private GameObject _previousHolder;
    Collider col;
    private void Start()
    {
        col = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().Pos = new Vector3(0, 3, 25);
        _previousSpawner.SetActive(false);
        _nextSpawner.SetActive(true);
        
    }
    private void OnTriggerExit(Collider other)
    {
        col.isTrigger = false;
        _previousHolder.SetActive(false);
    }
}
