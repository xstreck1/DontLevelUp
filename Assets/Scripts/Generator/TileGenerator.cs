using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab;

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
                float height = Mathf.PerlinNoise((float) x*.95f, (float)z * .95f);
                Debug.Log(x + ", " + z + ": " + height);
                GameObject newTile = Instantiate(tilePrefab, new Vector3(x, height / 2f, z), Quaternion.identity, tilesHolder.transform);
                newTile.transform.localScale += Vector3.up * (height - .5f);
            }
        }
    }
}
