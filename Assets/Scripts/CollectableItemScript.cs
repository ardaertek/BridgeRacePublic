using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemScript : MonoBehaviour
{
    [SerializeField] private int _colorID;
    [SerializeField] private Collider _closeCollider;
    public int ColorID { get => _colorID; }
    [SerializeField] Collider col;
    public void OffCollider()
    {
        col.enabled = false;
    }
    public void OnCollider()
    {
        col.enabled = true;
    }
    public void OffObstacleCollider()
    {
        _closeCollider.enabled = false;
    }
    private void Update()
    {
        transform.forward = transform.parent.transform.forward;
    }
}
