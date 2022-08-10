using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private ItemCollector IC;
    [SerializeField] Transform nextlevel;

    //AI
    AIController AIC;
    //---
    public int Index;

    private void OnTriggerEnter(Collider other)
    {
        IC = other.GetComponentInChildren<ItemCollector>();
        if (other.TryGetComponent(out AIC))
        {
            AIC._steCount = Index;
            AIC._doBridge = true;
        }
        IC.SetDoBridge(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AIC))
        {
            AIC._doBridge = false;
        }
        IC.SetDoBridge(false);
    }
}
