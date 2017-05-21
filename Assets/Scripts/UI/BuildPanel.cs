using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanel : MonoBehaviour {
    public Button buildButton;
    public Text title;
    public Text cost;

    TileType currentType = TileType.UnderWater;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentType == TileType.Factory)
        {
            buildButton.interactable = Logic.Instance.Money > Values.NATURE_COST;
        }
        else if(currentType == TileType.Green)
        {
            buildButton.interactable = Logic.Instance.Money > Values.FACTORY_COST;
        }
        else
        {
            buildButton.interactable = false;
        }
    }

    public void SetType(TileType tileType)
    {
        currentType = tileType;

        if (tileType == TileType.Factory)
        {
            title.text = Strings.FACTORY_TITLE;
            cost.text = Values.NATURE_COST.ToString();
        }
        else if (tileType == TileType.Green)
        {
            title.text = Strings.GREEN_TITLE;
            cost.text = Values.FACTORY_COST.ToString();
        }
        if (tileType == TileType.UnderWater)
        {
            title.text = Strings.UNDER_WATER_TITLE;
            cost.text = "";
        }
    }

    public void Convert()
    {
        Debug.Log("Convert");
    }
}
