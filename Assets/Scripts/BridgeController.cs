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
        Index += IC.GetInventory.GetIndex();
        if (other.TryGetComponent(out AIC))
        {
            AIC._stepCount = Index;
            AIC.DoBridge = true;
        }
        IC.SetDoBridge(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AIC))
        {
            AIC.DoBridge = false;
            
        }
        IC.SetDoBridge(false);
    }
    private void Update()
    {
        if (Index == 26)
        {
            Debug.Log("26");
        }
    }

}
