using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private ItemCollector IC;
    [SerializeField] private DoBridge DB;
    private void OnTriggerEnter(Collider other)
    {
        IC = other.GetComponentInChildren<ItemCollector>();
        DB = other.GetComponentInChildren<DoBridge>();
        DB.enabled = true;
        IC.SetDoBridge(true);
        DB.SetDoBridge(true);
        IC.GetInventory.BridgeCourutineStarter();
    }
    private void OnTriggerExit(Collider other)
    {
        DB.enabled = false;
        IC.SetDoBridge(false);
        DB.SetDoBridge(false);
        IC.GetInventory.BridgeCourutineStoper();
    }
}
