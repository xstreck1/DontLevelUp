using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Results
{
    static public float Money = 0f;
    static public float WaterDiff = 0f;

    static public void SetResults()
    {
        Money = Logic.Instance.Money;
        WaterDiff = GameWater.Instance.WaterHeight - Values.START_WATER_HEIGHT;
    }
}
