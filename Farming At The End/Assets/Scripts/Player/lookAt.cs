using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    [SerializeField] public GameObject lookAtObject;
    [SerializeField] private LayerMask lookMask;
    [SerializeField] private float maxDistance;
    [SerializeField] private Transform cameraTransform;
    
    private Vector3 forward;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    void updateForward()
    {
        forward = cameraTransform.forward;
    }

    void Raycast()
    {
        updateForward();
        RaycastHit hit;
        Ray ray = new Ray(cameraTransform.position, forward);
        if (Physics.Raycast(ray, out hit, maxDistance, lookMask))
        {
            lookAtObject = hit.transform.gameObject;
        }
        else
        {
            lookAtObject = null;
        }
    }
}
