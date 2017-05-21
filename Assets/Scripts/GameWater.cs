using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWater : MonoBehaviour {
    static GameWater instance;
    static public GameWater Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
    }

    public float WaterHeight
    {
        get
        {
            return transform.localScale.y;
        }
        set
        {
            transform.localScale = new Vector3(1f, value, 1f);
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHeight(float howMuch)
    {
        WaterHeight = Values.START_WATER_HEIGHT + howMuch;

        if (WaterHeight < Values.WATER_LOWER_LIMIT)
            WaterHeight = Values.WATER_LOWER_LIMIT;
    }
}
