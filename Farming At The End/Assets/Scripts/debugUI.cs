using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class debugUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameObject.FindObjectOfType<toolController>().currentTool._name;

        //advance the day of all plants
        if (Input.GetKeyUp(KeyCode.P))
        {
            plantController[] plants = GameObject.FindObjectsOfType<plantController>();
            if (plants.Length > 0)
            {
                foreach (var p in plants)
                {
                    p.advanceDay();
                }
            }

            farmPlotController[] plots = GameObject.FindObjectsOfType<farmPlotController>();
            if (plots.Length>0)
            {
                foreach (var p in plots)
                {
                    p.isWatered = false;
                }
            }
        }
    }
}
