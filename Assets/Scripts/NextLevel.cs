using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private DoBridge DoBridge;
    [SerializeField] private GameObject _nextSpawner;
    [SerializeField] private GameObject _previousSpawner;
    [SerializeField] private GameObject _previousHolder;
    [SerializeField] private GameObject _nextFirstStepPos;
    [SerializeField] private GameObject _nextBridgePartsPos;
    Collider col;
    private void Start()
    {
        col = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _previousSpawner.SetActive(false);
        _nextSpawner.SetActive(true);
        DoBridge = other.GetComponent<DoBridge>();
        
    }
    private void OnTriggerExit(Collider other)
    {
        col.isTrigger = false;
        _previousHolder.SetActive(false);
        DoBridge.SetStepIndex(0);
        DoBridge.SetFirstStepPos(_nextFirstStepPos.transform);
        DoBridge.SetBridgePartsPos(_nextBridgePartsPos);
    }
}
