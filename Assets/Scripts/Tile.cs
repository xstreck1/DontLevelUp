using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum TileType
{
    Factory,
    Green,
    UnderWater
}

public class Tile : MonoBehaviour {
    public GameObject groundHolder;
    public GameObject natureTop;
    public GameObject civilizationTop;
    public TileType type;
    public int X, Y;

    public TileType Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    void Awake()
    {
        Logic.Instance.Tiles[X, Y] = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
