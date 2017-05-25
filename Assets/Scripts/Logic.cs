using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public FinalScreen finalScreen;

    static Logic instance;
    static public Logic Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
    }

    [System.NonSerialized]public Tile[,] Tiles = new Tile[Values.TILES_X_COUNT, Values.TILES_Z_COUNT];
    public float CO2Level, Temperature, Money, CurrentYear;


    float CarbonDelta = 0f, TempDelta = 0f, MoneyDelta = 0f;
    // Use this for initialization
    //TileContainer[,] Tiles;

    void Start()
    {
        CO2Level = Values.START_CO2_LEVEL;
        Temperature = Values.START_TEMP;
        Money = Values.START_MONEY;
        CurrentYear = Values.START_YEAR;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int greenCount = 0, factoryCount = 0, waterCount = 0; 
        for (int x = 0; x < Values.TILES_X_COUNT; x++)
        {
            for (int z = 0; z < Values.TILES_Z_COUNT; z++)
            {
                if (Tiles[x, z] == null)
                    return;
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


        if ((CurrentYear += (1 / Values.SECONDS_PER_YEAR) * Time.deltaTime) >= Values.END_YEAR)
        {
            Results.SetResults();
            SceneManager.LoadScene("endScene");
            return;
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
        if (Temperature < 0)
            Temperature = 0;

        GameWater.Instance.ChangeHeight((Temperature - Values.START_TEMP) * Values.TEMP_HEIGHT_SCALE);

        MoneyDelta = factoryCount * Values.FACTORY_MONEY_SCALE;
        Money += Time.deltaTime * MoneyDelta;
        UIManager.Instance.MoneyText.text = "Money: " + (int)Money + "B €";
        UIManager.Instance.CarbonText.text = "CO<size=20>2</size>: " + (int)CO2Level + " (PPM)";
        UIManager.Instance.TempText.text = "Temp: " + (int)(Temperature) + "°C";
        UIManager.Instance.YearText.text = "Year: " + (int)CurrentYear;
        UIManager.Instance.EndYearText.text = "Ends in " + (int)Mathf.Ceil(Values.END_YEAR - CurrentYear);

        UIManager.Instance.MoneyDeltaText.text = "Δ " + (MoneyDelta* Values.SECONDS_PER_YEAR).ToString("0.000") + "/y";
        UIManager.Instance.CarbonDeltaText.text = "Δ " + (CarbonDelta * Values.SECONDS_PER_YEAR).ToString("0.000") + "/y";
        UIManager.Instance.TempDeltaText.text = "Δ " + (TempDelta * Values.SECONDS_PER_YEAR).ToString("0.000") + "/y";
    }
}
