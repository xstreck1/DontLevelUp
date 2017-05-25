using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Values
{
    public const int TILES_X_COUNT = 15;
    public const int TILES_Z_COUNT = 10;

    public const float START_WATER_HEIGHT = .6f;
    public const int START_YEAR = 2017;
    public const int PLAY_YEARS = 300;
    public const int END_YEAR = START_YEAR + PLAY_YEARS;
    public const float START_MONEY = 10;
    public const float START_TEMP = 14;
    public const float START_CO2_LEVEL = 400f;


    public const float FACTORY_GENERATION_CHANCE = 0.25f;

    public const float GREEN_CARBON_SCALE = 0.025f;
    public const float FACTORY_CARBON_SCALE = .25f;
    public const float WATER_CARBON_SCALE = 0.01f;

    public const float TEMP_CARBON_SCALE = 0.0003f;
    public const float TEMP_HEIGHT_SCALE = .1f;
    public const float FACTORY_MONEY_SCALE = .1f;

    public const float NATURE_COST = 2f;
    public const float FACTORY_COST = 5f;

    public const float SECONDS_PER_YEAR = 1f;

    public const float CARBON_LOWER_LIMIT = 150f;
    public const float WATER_LOWER_LIMIT = .25f;

    public const float METER_TO_REAL_METER = .5f;
}
