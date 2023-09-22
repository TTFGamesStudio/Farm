using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheatController : plantController
{
    [SerializeField] private MeshRenderer[] stages;
    // Start is called before the first frame update
    void Start()
    {
        toggleMeshes(true,false,false,false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (growth)
        {
            case 0:
                toggleMeshes(true,false,false,false);
                break;
            case 1:
                toggleMeshes(false,true,false,false);
                break;
            case 2:
                toggleMeshes(false,true,false,false);
                break;
            case 3:
                toggleMeshes(false,false,true,false);
                break;
            case 4:
                toggleMeshes(false,false,true,false);
                break;
            case 5:
                toggleMeshes(false,false,false,true);
                readyToHarvest = true;
                break;
        }
    }

    public void grow()
    {
        base.grow();
    }

    public void toggleMeshes(bool stage1, bool stage2, bool stage3, bool stage4 )
    {
        stages[0].enabled = stage1;
        stages[1].enabled = stage2;
        stages[2].enabled = stage3;
        stages[3].enabled = stage4;
        stages[3].GetComponent<MeshCollider>().enabled = stage4;
    }

    public void activate()
    {
        if (readyToHarvest)
        {
            //harvest the wheat
            Destroy(transform.parent.gameObject);
        }
    }
}
