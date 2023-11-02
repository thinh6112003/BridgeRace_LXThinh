using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    public List<GameObject> listBrick = new List<GameObject>();
    private void LateUpdate()
    { 
        transform.position = target.position + offset;
    }
}
