using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormatWater : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string waterChangeString = Results.WaterDiff > 0f ? Strings.INCREASED : Strings.DECREASED;
        GetComponent<Text>().text = String.Format(GetComponent<Text>().text, waterChangeString, (int) (Results.WaterDiff * 1000));
    }
}
