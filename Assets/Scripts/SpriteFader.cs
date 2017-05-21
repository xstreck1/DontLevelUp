using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    [SerializeField]float FadeTime = 1f;
    Renderer Rend;
    // Use this for initialization
    void Awake()
    {
        Rend = GetComponent<Renderer>();
    }
    void OnEnable()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float EndTime = Time.time + FadeTime;
        Color col = Color.white;

        while(Time.time < EndTime)
        {
            col.a = 1f - ((EndTime - Time.time) / FadeTime);
            Rend.material.color = col;
            yield return null;
        }

        col.a = 1f;
        Rend.material.color = col;
    }
}
