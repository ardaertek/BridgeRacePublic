using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private ItemCollector IC;
    //[SerializeField] private DoBridge DB;
    [SerializeField] private BridgeMaker BM;
    [SerializeField] Transform nextlevel;

    //AI
    AIController AIC;
    //---
    public int Index;

    private void OnTriggerEnter(Collider other)
    {
        IC = other.GetComponentInChildren<ItemCollector>();
        BM = other.GetComponentInChildren<BridgeMaker>();
        if (other.TryGetComponent(out AIC))
        {
            AIC._doBridge = true;
        }
        IC.SetDoBridge(true);
        BM.SetDoBridge(true);
        Index += IC.GetInventory.ItemList.Count;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AIC))
        {
            AIC._doBridge = false;
        }
        IC.SetDoBridge(false);
        BM.SetDoBridge(false);
    }
}
