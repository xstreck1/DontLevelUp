using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    public string linkURL;

    public EventSystem eventSystem;

    public void OnClick()
    {
        eventSystem.SetSelectedGameObject(null);
        Application.OpenURL(linkURL);
    }

}
