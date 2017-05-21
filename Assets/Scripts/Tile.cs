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
    public GameObject top;
    public GameObject natureTop;
    public GameObject civilizationTop;
    public int X, Y;
    public float Height;

    [SerializeField] TileType type;
    public TileType Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
            switch (type)
            {
                case TileType.Factory:
                    natureTop.SetActive(false);
                    civilizationTop.SetActive(true);
                    break;
                case TileType.Green:
                    natureTop.SetActive(true);
                    civilizationTop.SetActive(false);
                    break;
                case TileType.UnderWater:
                    natureTop.SetActive(false);
                    civilizationTop.SetActive(false);
                    break;
            }

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
	void Update ()
    {
        if (Height <= Logic.Instance.WaterHeight)
        {
            if(Type != TileType.UnderWater)
                Type = TileType.UnderWater;
        }
        else
        {
            if (Type == TileType.UnderWater)
                Type = TileType.Green;
        }
    }
}
