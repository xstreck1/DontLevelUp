using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [System.NonSerialized]public Tile[,] Tiles = new Tile[Values.TILES_X_COUNT, Values.TILES_Z_COUNT];
    // Use this for initialization
    //TileContainer[,] Tiles;

    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	}
}
