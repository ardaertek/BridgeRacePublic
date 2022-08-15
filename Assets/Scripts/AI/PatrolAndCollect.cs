using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PatrolAndCollect : IState
{
    Collider[] _collectableObjects;
    StateMachine _stateMachine;
    NavMeshAgent _nav;
    LevelHolder _levelHolder;
    LayerMask _cubeLayer;

    public PatrolAndCollect(StateMachine stateMachine,NavMeshAgent nav,LayerMask cubeLayer,LevelHolder levelHolder)
    {
        _stateMachine = stateMachine;
        _nav = nav;
        _cubeLayer = cubeLayer;
        _levelHolder = levelHolder;
    }

    public void OnStart()
    {
        _collectableObjects = Physics.OverlapSphere(_stateMachine.transform.position, 4f, _cubeLayer);
        if (_collectableObjects.Length != 0) _nav.SetDestination(_mostCloseObject());
        else _nav.SetDestination(_randomPatrolling());
    }
    public void OnExit()
    {

    }

    GameObject _mostCloseObjectG;
    float dis1, dis2;
    private Vector3 _mostCloseObject()
    {
        _mostCloseObjectG = _collectableObjects[0].gameObject;
        for (int i = 0; i < _collectableObjects.Length - 1; i++)
        {
            for (int j = i + 1; j < _collectableObjects.Length; j++)
            {
                dis1 = Vector3.Distance(_collectableObjects[j].transform.position, _stateMachine.transform.position);
                dis2 = Vector3.Distance(_collectableObjects[i].transform.position, _stateMachine.transform.position);
                if (dis1 < dis2)
                {
                    _mostCloseObjectG = _collectableObjects[j].gameObject;
                }
            }
        }
        return _mostCloseObjectG.transform.position;
    }

    Vector3 _patrolPoint;
    [SerializeField] float _movementDistancex = 10;
    [SerializeField] float _movementDistancez = 6;
    private Vector3 _randomPatrolling()
    {
        float xPos = Random.Range(_stateMachine.transform.position.x - _movementDistancex, _stateMachine.transform.position.x + _movementDistancex);
        float zPos = Random.Range(_stateMachine.transform.position.z - _movementDistancez, _stateMachine.transform.position.z + _movementDistancez);
        _patrolPoint = new Vector3(xPos, 0, zPos);
        return _patrolPoint;
    }

    
}
