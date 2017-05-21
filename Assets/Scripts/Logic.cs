using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    static Logic instance;
    static public Logic Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
    }
    public Transform Water;
    public Text Data;

    [System.NonSerialized]public Tile[,] Tiles = new Tile[Values.TILES_X_COUNT, Values.TILES_Z_COUNT];
    public float CO2Level = Values.START_CO2_LEVEL, WaterHeight = Values.START_WATER_HEIGHT, Temperature = +0f, Money = 100f;

    // Use this for initialization
    //TileContainer[,] Tiles;

    void Start()
    {
        CO2Level = Values.START_CO2_LEVEL;
        WaterHeight = Values.START_WATER_HEIGHT;
        Temperature = +0f;
        Money = 10f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int greenCount = 0, factoryCount = 0, waterCount = 0; 
        for (int x = 0; x < Values.TILES_X_COUNT; x++)
        {
            for (int z = 0; z < Values.TILES_Z_COUNT; z++)
            {
                switch (Tiles[x,z].Type)
                {
                    case TileType.Factory:
                        factoryCount++;
                        break;
                    case TileType.Green:
                        greenCount++;
                        break;
                    case TileType.UnderWater:
                        waterCount++;
                        break;
                }
            }
        }
        if(waterCount == (Values.TILES_X_COUNT * Values.TILES_Z_COUNT))
        {
            //game over?
        }


        CO2Level += Time.deltaTime * ( -(greenCount * Values.GREEN_CARBON_SCALE) + (factoryCount * Values.FACTORY_CARBON_SCALE) - (waterCount * Values.WATER_CARBON_SCALE));
        if (CO2Level < 0)
            CO2Level = 0;
        Temperature += Time.deltaTime * (CO2Level - 280f) * Values.TEMP_CARBON_SCALE;
        if (Temperature < 0)
            Temperature = 0;
        WaterHeight = Values.START_WATER_HEIGHT + (Temperature * Values.TEMP_HEIGHT_SCALE);//???
        if (WaterHeight < 0)
            WaterHeight = 0;
        Money += Time.deltaTime * factoryCount * Values.FACTORY_MONEY_SCALE;
        Data.text = "Money: €" + (int)Money + "\nCarbon(PPM): " + (int)CO2Level + "\nTemperature(Celcius): " + (int) (14f + Temperature);
        Water.localScale = new Vector3(1f, WaterHeight, 1f);
    }
}
