using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    IState activeState;
    NavMeshAgent nav;
    [SerializeField] LayerMask _cubeLayer;
    PatrolAndCollect patrolandcollect;
    BridgeMaker bridgeMaker;
    PlayerBag _inventory;
    [SerializeField] LevelHolder _levelHolder;
    private void Awake()
    {
        _inventory = GetComponentInChildren<PlayerBag>();
        nav = GetComponent<NavMeshAgent>();
        patrolandcollect = new PatrolAndCollect(this, nav, _cubeLayer, _levelHolder);
        bridgeMaker = new BridgeMaker();
    }

    private void Start()
    {
        SetState(patrolandcollect);
    }

    private void Update()
    {
        if (_inventory.ItemList.Count < 8)
        {
            SetState(patrolandcollect);
        }
        else
        {
            SetState(bridgeMaker);
        }
    }


    public void SetState(IState state)
    {
        Debug.Log("SetState");
        CheckState(activeState);
        activeState = state;
        activeState.OnStart();
    }

    public IState CheckState(IState state)
    {
        if (state != null)
        {
            state = null;
            return state;
        }
        else return state;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }

}
