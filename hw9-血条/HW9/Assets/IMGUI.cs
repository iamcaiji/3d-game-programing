using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour {

    private void OnGUI()
    {
        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Rect rect = new Rect(screenPos.x + 100,screenPos.y + 100 ,100,100);
        GUI.HorizontalScrollbar(rect, 0, 100, 0, 100);
    }
}
