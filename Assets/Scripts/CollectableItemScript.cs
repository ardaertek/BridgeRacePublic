using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItemScript : MonoBehaviour
{
    [SerializeField] private int _colorID;
    public int ColorID { get => _colorID; }
    Collider col;
    private bool _canCollect = true;
    public bool CanCollect { get { return _canCollect; } set { _canCollect = value; }  }
    private void Start()
    {
        col = GetComponent<Collider>();
    }
    public void OffCollider()
    {
        col.enabled = false;
    }
    public void OnCollider()
    {
        col.enabled = true;
    }
    private void Update()
    {
        transform.forward = transform.parent.transform.forward;
    }
}
