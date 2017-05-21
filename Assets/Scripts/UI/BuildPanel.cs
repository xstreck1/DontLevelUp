using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanel : MonoBehaviour {
    public Button buildButton;
    public Text title;
    public Text cost;

    Tile currentTile = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTile.Type == TileType.Factory)
        {
            buildButton.interactable = Logic.Instance.Money > Values.NATURE_COST;
        }
        else if(currentTile.Type == TileType.Green)
        {
            buildButton.interactable = Logic.Instance.Money > Values.FACTORY_COST;
        }
        else
        {
            buildButton.interactable = false;
        }
    }

    public void SetTile(Tile tile)
    {
        currentTile = tile;

        if (currentTile.Type == TileType.Factory)
        {
            title.text = Strings.FACTORY_TITLE;
            cost.text = Values.NATURE_COST + "B €";
        }
        else if (currentTile.Type == TileType.Green)
        {
            title.text = Strings.GREEN_TITLE;
            cost.text = Values.FACTORY_COST + "B €";
        }
        if (currentTile.Type == TileType.UnderWater)
        {
            title.text = Strings.UNDER_WATER_TITLE;
            cost.text = "";
        }
    }

    public void Convert()
    {
        if (currentTile.Type == TileType.Factory)
        {
            currentTile.Type = TileType.Green;
            Logic.Instance.Money -= Values.NATURE_COST;
        }
        else if (currentTile.Type == TileType.Green)
        {
            currentTile.Type = TileType.Factory;
            Logic.Instance.Money -= Values.FACTORY_COST;
        }
        SetTile(currentTile);
    }
}
