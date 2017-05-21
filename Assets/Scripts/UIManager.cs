using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    static public UIManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;
    }
    [SerializeField]public Text MoneyText, TempText, CarbonText, YearText, MoneyDeltaText, TempDeltaText, CarbonDeltaText;

}
