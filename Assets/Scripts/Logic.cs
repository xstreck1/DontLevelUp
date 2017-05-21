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

    [System.NonSerialized]public Tile[,] Tiles = new Tile[Values.TILES_X_COUNT, Values.TILES_Z_COUNT];
    public float CO2Level = Values.START_CO2_LEVEL, WaterHeight = Values.START_WATER_HEIGHT, Temperature = +0f, Money = 100f, CurrentYear = 0f;


    float LastYearIncrement = 0f, CarbonDelta = 0f, TempDelta = 0f, MoneyDelta = 0f;
    // Use this for initialization
    //TileContainer[,] Tiles;

    void Start()
    {
        CO2Level = Values.START_CO2_LEVEL;
        WaterHeight = Values.START_WATER_HEIGHT;
        Temperature = +0f;
        Money = 10f;
        CurrentYear = 0f;
        LastYearIncrement = Time.time;
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


        if (LastYearIncrement + Values.SECONDS_PER_YEAR < Time.time)
        {
            LastYearIncrement = Time.time;
            CurrentYear++;
        }
        if(CurrentYear >= Values.YEAR_LIMIT)
        {
            //game end?
        }
        if (waterCount == (Values.TILES_X_COUNT * Values.TILES_Z_COUNT))
        {
            //game over?
        }

        CarbonDelta = (-(greenCount * Values.GREEN_CARBON_SCALE) + (factoryCount * Values.FACTORY_CARBON_SCALE) - (waterCount * Values.WATER_CARBON_SCALE));
        CO2Level += Time.deltaTime * CarbonDelta;
        if (CO2Level < Values.CARBON_LOWER_LIMIT)
            CO2Level = Values.CARBON_LOWER_LIMIT;
        TempDelta = (CO2Level - 280f) * Values.TEMP_CARBON_SCALE;
        Temperature += Time.deltaTime * TempDelta;
        if (Temperature < -Values.TEMP_START)
            Temperature = Values.TEMP_START;
        WaterHeight = Values.START_WATER_HEIGHT + (Temperature * Values.TEMP_HEIGHT_SCALE);
        if (WaterHeight < 0)
            WaterHeight = 0;
        MoneyDelta = factoryCount * Values.FACTORY_MONEY_SCALE;
        Money += Time.deltaTime * MoneyDelta;
        UIManager.Instance.MoneyText.text = "Money: €" + (int)Money;
        UIManager.Instance.CarbonText.text = "Carbon(PPM): " + (int)CO2Level;
        UIManager.Instance.TempText.text = "Temperature(Celcius): " + (int)(Values.TEMP_START + Temperature);
        UIManager.Instance.YearText.text = "Year: " + (int)CurrentYear;
        
        UIManager.Instance.MoneyDeltaText.text = (MoneyDelta* Values.SECONDS_PER_YEAR).ToString("0.000") + "/y";
        UIManager.Instance.CarbonDeltaText.text = "    " + (CarbonDelta * Values.SECONDS_PER_YEAR).ToString("0.000") + "/y";
        UIManager.Instance.TempDeltaText.text = "    " + (TempDelta * Values.SECONDS_PER_YEAR).ToString("0.000") + "/y";
        Water.localScale = new Vector3(1f, WaterHeight, 1f);
    }
}
