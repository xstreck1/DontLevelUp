using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameWater water;
    public GameObject tilePrefab;
	public float noiseScale = 10f;
	public float heightVariance = 1f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateTiles()
    {
        water.WaterHeight = Values.START_WATER_HEIGHT;

        // Clean existing
        if (GameObject.Find(Strings.TILES_HOLDER))
        {
            DestroyImmediate(GameObject.Find(Strings.TILES_HOLDER));
        }
        Transform tilesHolder = new GameObject(Strings.TILES_HOLDER).transform;

        // Generate new
        float randomx = Random.Range(-1000f, 1000f);
        float randomz = Random.Range(-1000f, 1000f);
        for (int x = 0; x < Values.TILES_X_COUNT; x++)
        {
            for (int z = 0; z < Values.TILES_Z_COUNT; z++)
            {
                Tile newTile = Instantiate(tilePrefab, new Vector3(-x, 0f, -z ), Quaternion.identity, tilesHolder.transform).GetComponent<Tile>();
                newTile.gameObject.SetActive(true);
                float height = heightVariance * Mathf.PerlinNoise(randomx + (((float)x / Values.TILES_X_COUNT) * noiseScale), randomz + (((float)z / Values.TILES_Z_COUNT) * noiseScale));
                // Clamping
                if (height < 0.05f)
                {
                    height = 0.05f;
                }
                newTile.groundHolder.transform.localScale += Vector3.up * (height - 1f);
                newTile.top.transform.Translate(Vector3.up * height);
                newTile.X = x;
                newTile.Y = z;
                newTile.Height = height;
                if (height > Values.START_WATER_HEIGHT)
                {
                    if (Random.Range(0f, 1f) < Values.FACTORY_GENERATION_CHANCE)
                    {
                        newTile.Type = TileType.Factory;
                    }
                    else
                    {
                        newTile.Type = TileType.Green;
                    }
                }
                else
                {
                    newTile.Type = TileType.UnderWater;
                }
            }
        }
    }
}
