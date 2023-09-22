using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantController : MonoBehaviour
{
    public farmPlotController plot;

    public int unwateredDays = 0;

    public bool readyToHarvest = false;
    public int growth;

    public int maxGrowth = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation=Quaternion.Euler(0,Random.Range(0,360),0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void grow()
    {
        unwateredDays = 0;
        growth++;
        growth = Mathf.Clamp(growth,0, maxGrowth);
    }

    public void advanceDay()
    {
        if (plot.isWatered)
        {
            if (!readyToHarvest)
            {
                grow();
            }
        }
        else
        {
            unwateredDays++;
            if (unwateredDays >= 2)
            {
                plot.isSeeded = false;
                plot.plant = null;
                Destroy(gameObject);
            }
        }
    }
}
