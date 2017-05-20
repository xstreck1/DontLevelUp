using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Picking : MonoBehaviour {
    public GameObject mainCamera;
    public LayerMask pickingLayer;

    public static Vector2 PointerPosition()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }
        else
        {
            return Input.mousePosition;
        }
    }

    bool PointerDown()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0);
        }
        else
        {
            return Input.GetMouseButtonDown(0);
        }
    }


    GameObject PointerHit()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(PointerPosition());
        // TODO: Make this ignore the picking layer
        if (Physics.Raycast(ray, out hit, 100.0f, pickingLayer.value))
        {
            return hit.transform.parent.gameObject;
        }
        else
        {
            return null;
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (PointerDown())
        {
            GameObject hit = PointerHit();
            if (hit)
            {
                Tile tileHit = hit.GetComponentInParent<Tile>();
                if (tileHit)
                {
                    Debug.Log("hit tile X" + tileHit.X + ", Y:" + tileHit.Y);
                }
                else
                {
                    Debug.Log("hit " + hit.name);
                }
            }
        }
    }
}
