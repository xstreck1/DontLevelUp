using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanel : MonoBehaviour {
    public Button buildButton;
    public Text title;
    public Text cost;
    public Text height;
    public Text convertText;
    public GameObject bgCiv;
    public GameObject bgGreen;
    public GameObject bgWat;

    Tile currentTile = null;
    TileType lastType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (lastType != currentTile.Type)
        {
            SetTile(currentTile);
        }

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
        height.text = "Height: " + ((currentTile.Height - GameWater.Instance.WaterHeight) * Values.METER_TO_REAL_METER).ToString("0.000") + "m MSL";
    }

    public void SetTile(Tile tile)
    {
        currentTile = tile;
        lastType = tile.Type;

        if (currentTile.Type == TileType.Factory)
        {
            title.text = Strings.FACTORY_TITLE;
            convertText.text = Strings.CLEAR_BUSINESS;
            cost.text = Values.NATURE_COST + "B €";
            bgGreen.SetActive(false);
            bgCiv.SetActive(true);
            bgWat.SetActive(false);
        }
        else if (currentTile.Type == TileType.Green)
        {
            title.text = Strings.GREEN_TITLE;
            convertText.text = Strings.BUILD_BUSINESS;
            cost.text = Values.FACTORY_COST + "B €";
            bgGreen.SetActive(true);
            bgCiv.SetActive(false);
            bgWat.SetActive(false);
        }
        else if (currentTile.Type == TileType.UnderWater)
        {
            title.text = Strings.UNDER_WATER_TITLE;
            convertText.text = "";
            cost.text = "";
            bgGreen.SetActive(false);
            bgCiv.SetActive(false);
            bgWat.SetActive(true);
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
        GetComponent<AudioSource>().Play();
    }
}
