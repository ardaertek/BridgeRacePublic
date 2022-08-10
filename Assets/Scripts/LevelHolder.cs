using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelHolder : MonoBehaviour
{
    [SerializeField] public Bridges[] Bridge;
    [SerializeField] public Spawners[] Spawners;
    public Transform LevelPosition;
    public Transform[] BridgesTransform;

    private void Awake()
    {
        LevelPosition = transform;
        Bridge = GetComponentsInChildren<Bridges>();
        Spawners = GetComponentsInChildren<Spawners>();
    }

    public void FindSpawner(GameObject obj,bool value)
    {
        for (int i = 0; i < Spawners.Length; i++)
        {
            if (Spawners[i].gameObject.layer == obj.layer)
            {
                Spawners[i].GetComponent<CollectableObjects>().enabled = value;
                Spawners[i].gameObject.SetActive(value);
                break;
            }
        }
    }
}
