using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolController : MonoBehaviour
{
    public List<tool> tools;
    public tool currentTool;
    public lookAt lookTarget;
    public int toolIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        updateTool();
        lookTarget = GetComponent<lookAt>();
    }

    // Update is called once per frame
    void Update()
    {
        interact();
        scrollItems();
    }

    private void interact()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (lookTarget.lookAtObject != null)
            {
                lookTarget.lookAtObject.SendMessageUpwards("activate",currentTool,SendMessageOptions.DontRequireReceiver);
            }
            
        }
    }

    private void scrollItems()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            toolIndex--;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            toolIndex++;
        }

        if (toolIndex < 0)
        {
            toolIndex = tools.Count - 1;
        }

        if (toolIndex >= tools.Count)
        {
            toolIndex = 0;
        }
        updateTool();
    }

    private void updateTool()
    {
        currentTool = tools[toolIndex];
    }
}
