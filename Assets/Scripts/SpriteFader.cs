using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    [SerializeField]float FadeTime = 1f;
    Renderer Rend;
    
    [SerializeField]public bool HasDeathFade = false;
    // Use this for initialization
    void Awake()
    {
        Rend = GetComponent<Renderer>();
    }
    void OnEnable()
    {
        StartCoroutine(Fade(true));
    }
    public void StartDeathFade()
    {
        StartCoroutine(Fade(false));
    }
    
    IEnumerator Fade(bool FadeIn)
    {
        float EndTime = Time.time + FadeTime;
        Color col = Color.white;

        while(Time.time < EndTime)
        {
            if(FadeIn)
                col.a = 1f - ((EndTime - Time.time) / FadeTime);
            else
                col.a = ((EndTime - Time.time) / FadeTime);
            Rend.material.color = col;
            yield return null;
        }
        if (FadeIn)
            col.a = 1f;
        else
        {
            col.a = 0f;
            gameObject.SetActive(false);
        }
        Rend.material.color = col;
    }
}
