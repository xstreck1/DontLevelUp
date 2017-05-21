using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour {
    [SerializeField]Texture2D[] InitialTextures;
    [SerializeField]Texture2D[] AnimLoopTextures;
    [SerializeField]float AnimDelay = 0.5f;
    int Count = 0;
    bool UsingInitialTextures = true;
    float LastIncrement = 0f;
    Renderer Rend;
    // Use this for initialization
    void Awake()
    {
        Rend = GetComponent<Renderer>();
    }
    void OnEnable ()
    {
        LastIncrement = Time.time + Random.Range(0f, 1f);
        Count = 0;
        if (InitialTextures.Length > 0)
        {
            UsingInitialTextures = true;
            Rend.material.mainTexture = InitialTextures[0];
        }
        else
        {
            UsingInitialTextures = false;
            Rend.material.mainTexture = AnimLoopTextures[0];
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((LastIncrement + AnimDelay) < Time.time)
        { 
            LastIncrement = Time.time;
            Count++;
            if (UsingInitialTextures)
            {
                if (Count >= InitialTextures.Length)
                {
                    Rend.material.mainTexture = AnimLoopTextures[0];
                    UsingInitialTextures = false;
                    Count = 0;
                }
                else
                    Rend.material.mainTexture = InitialTextures[Count];
            }
            else
            {
                if (Count >= AnimLoopTextures.Length)
                {
                    Rend.material.mainTexture = AnimLoopTextures[0];
                    Count = 0;
                }
                else
                    Rend.material.mainTexture = AnimLoopTextures[Count];
            }
        }
	}
}
