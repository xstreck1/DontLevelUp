﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormatMoney : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = String.Format(GetComponent<Text>().text, (int)Results.Money);
    }
}
