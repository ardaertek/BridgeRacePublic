using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private ItemCollector IC;
    //[SerializeField] private DoBridge DB;
    [SerializeField] private BridgeMaker BM;
    private void OnTriggerEnter(Collider other)
    {
        IC = other.GetComponentInChildren<ItemCollector>();
        //DB = other.GetComponentInChildren<DoBridge>();
        BM = other.GetComponentInChildren<BridgeMaker>();
        //DB.enabled = true;
        IC.SetDoBridge(true);
        BM.SetDoBridge(true);
        //DB.SetDoBridge(true);
        //IC.GetInventory.BridgeCourutineStarter();
    }
    private void OnTriggerExit(Collider other)
    {
        //DB.enabled = false;
        IC.SetDoBridge(false);
        BM.SetDoBridge(false);
        //DB.SetDoBridge(false);
        //IC.GetInventory.BridgeCourutineStoper();
    }
}
