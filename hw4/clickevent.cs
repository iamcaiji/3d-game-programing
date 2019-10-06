using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class clickevent : MonoBehaviour {
    
    public void Start()
    {
        //为相机添加3个组件
        if (this.gameObject.GetComponent<PhysicsRaycaster>() == null) {
            gameObject.AddComponent<PhysicsRaycaster>();
        }
        if (this.gameObject.GetComponent<EventSystem>() == null)
        {
            this.gameObject.AddComponent<EventSystem>();
        }
 
        if (this.gameObject.GetComponent<StandaloneInputModule>() == null)
        {
            gameObject.AddComponent<StandaloneInputModule>();
        }
    }
}
