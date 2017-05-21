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
    SpriteAnimator natureSpriteAnim;
    SpriteAnimator civilizationSpriteAnim;
    SpriteFader natureSpriteFade;
    SpriteFader civilizationSpriteFade;

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
                    if (natureTop.activeSelf && natureSpriteAnim != null && natureSpriteAnim.HasDeathAnim)
                        natureSpriteAnim.PlayDeath();
                    else if (natureTop.activeSelf && natureSpriteFade != null && natureSpriteFade.HasDeathFade)
                        natureSpriteFade.StartDeathFade();
                    else
                        natureTop.SetActive(false);
                    if (civilizationTop.activeSelf && civilizationSpriteAnim != null && civilizationSpriteAnim.HasDeathAnim)
                        civilizationSpriteAnim.PlayDeath();
                    else if (civilizationTop.activeSelf && civilizationSpriteFade != null && civilizationSpriteFade.HasDeathFade)
                        civilizationSpriteFade.StartDeathFade();
                    else
                        civilizationTop.SetActive(false);
                    break;
            }

        }
    }

    void Awake()
    {
        StartCoroutine(lateStart());

    }

    // Use this for initialization
    void Start () {
		
	}
	IEnumerator lateStart()
    {
        yield return null;
        Logic.Instance.Tiles[X, Y] = this;
        natureSpriteAnim = natureTop.GetComponent<SpriteAnimator>();
        civilizationSpriteAnim = civilizationTop.GetComponent<SpriteAnimator>();
        natureSpriteFade = natureTop.GetComponent<SpriteFader>();
        civilizationSpriteFade = civilizationTop.GetComponent<SpriteFader>();
    }
	// Update is called once per frame
	void Update ()
    {
        if (Height <= Logic.Instance.gameWater.WaterHeight)
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
