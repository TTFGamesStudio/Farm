using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float lookSpeed = 10f;
    [SerializeField] private float sharpness = 25f;
    [SerializeField] private bool invertY = true;
    [SerializeField] private Vector2 XClamp = new Vector2(-90f,90f);
    
    [SerializeField]private Vector2 input;
    [SerializeField]private Vector2 rot;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        calculateRot();
    }

    void calculateRot()
    {
        updateInput();
        if (invertY)
        {
            rot.x = smoothLerp(rot.x, rot.x + (input.y * lookSpeed), sharpness);
        }
        else
        {
            rot.x = smoothLerp(rot.x, rot.x + (-input.y * lookSpeed), sharpness);
        }

        rot.x = Mathf.Clamp(rot.x, XClamp.x, XClamp.y);

        rot.y = smoothLerp(rot.y, rot.y + (input.x * lookSpeed), sharpness);
        
        updateRotation();
    }

    float smoothLerp(float start, float end, float sharpness)
    {
        return Mathf.Lerp(start, end, 1f - Mathf.Exp(-sharpness * Time.deltaTime));
    }

    void updateInput()
    {
        input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    void updateRotation()
    {
        cameraTransform.localRotation = Quaternion.Euler(rot.x,0,0);
        playerTransform.rotation = Quaternion.Euler(0, rot.y, 0);
    }
}
