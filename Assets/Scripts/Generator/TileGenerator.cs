using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
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
        // Clean existing
        if (GameObject.Find(Strings.TILES_HOLDER))
        {
            DestroyImmediate(GameObject.Find(Strings.TILES_HOLDER));
        }
        Transform tilesHolder = new GameObject(Strings.TILES_HOLDER).transform;

        // Generate new
        for (int x = 0; x < Values.TILES_X_COUNT; x++)
        {
            for (int z = 0; z < Values.TILES_Z_COUNT; z++)
            {
				float height = heightVariance * Mathf.PerlinNoise(((float)x/(float)Values.TILES_X_COUNT) *noiseScale,((float)z/(float)Values.TILES_Z_COUNT)*noiseScale);
                GameObject newTile = Instantiate(tilePrefab, new Vector3(x, height / 2f, z), Quaternion.identity, tilesHolder.transform);
                newTile.transform.localScale += Vector3.up * (height - .5f);
            }
        }
    }
}
