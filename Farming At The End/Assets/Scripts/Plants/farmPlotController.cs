using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmPlotController : MonoBehaviour
{
    public static int plotIdTalley = 0;
    public int plotId = 0;
    public bool isWatered = false;
    public bool isSeeded = false;
    public Material dryMat;
    public Material wetMat;
    public Transform plantPosition;

    public GameObject wheatPrefab;

    public GameObject plant;

    private MeshRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        plotId = plotIdTalley;
        plotIdTalley++;
    }

    // Update is called once per frame
    void Update()
    {
        seedStatus();
        updateMat();
    }
    
    //check seed stats
    private void seedStatus()
    {
        if (isSeeded && plant == null)
        {
            isSeeded = false;
        }
    }

    public void updateMat()
    {
        List<Material> mats=new List<Material>();
        if (isWatered)
        {
            mats.Add(wetMat);
        }
        else
        {
            mats.Add(dryMat);
        }
        render.SetMaterials(mats);
    }

    public void activate(tool t)
    {
        Debug.Log(t._id);
        switch (t._id)
        {
            case 0:
                if (!isWatered)
                {
                    isWatered = true;
                }
                break;
            case 1:
                if (!isSeeded)
                {
                    isSeeded = true;
                    //wheat seed
                    GameObject g = Instantiate(wheatPrefab, plantPosition.position,Quaternion.identity);
                    plant = g;
                    g.GetComponentInChildren<plantController>().plot = this;
                }
                break;
            case 2:
                if (!isSeeded)
                {
                    isSeeded = true;
                    //corn seed
                }
                break;
            case 3:
                if (!isSeeded)
                {
                    isSeeded = true;
                    //tomato seed
                }
                break;
            default:
                //do nothing
                break;
        }
    }
}
