using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private float walkSpeed=10;
    [SerializeField] private Vector3 forward;
    [SerializeField] private Vector2 input;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    void walk()
    {
        updateInput();
        forward = transform.forward;
        Vector3 forwardMove = forward * walkSpeed * input.y * Time.deltaTime;
        Vector3 rightMove = transform.right * walkSpeed * input.x * Time.deltaTime;
        Vector3 combinedWalk = forwardMove + rightMove;
        character.Move(combinedWalk);
    }

    void updateInput()
    {
        input = new Vector2(smoothLerp(input.x,Input.GetAxis("Horizontal"),15f), smoothLerp(input.y,Input.GetAxis("Vertical"),15f));
    }
    
    float smoothLerp(float start, float end, float sharpness)
    {
        return Mathf.Lerp(start, end, 1f - Mathf.Exp(-sharpness * Time.deltaTime));
    }
}
