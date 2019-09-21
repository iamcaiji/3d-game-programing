using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PD;

public class CubeItem : MonoBehaviour
{
    public void OnClickCubeItem(UnityEngine.EventSystems.BaseEventData data = null) {
        Mygame mygame = Mygame.getMygame();
        string str = transform.name;
        if (str == "boat"){
            if (mygame._boat == 0){
                if (mygame.init_boat()) this.transform.position = new Vector3(2,1.1f,0);
            }
            else if(mygame._boat == 1){
                if (mygame.boat_seat > 0) mygame.boat_r2l(this.transform);
            }
            else {
                if (mygame.boat_seat > 0) mygame.boat_l2r(this.transform);
            }
            if (mygame.is_gameover()) 
                Debug.Log("You Lose!");
            if (mygame.is_win()) 
                Debug.Log("You Win!");
        }
        else if (str == "p1" || str == "p2" || str == "p3" || str == "d1" || str == "d2" || str == "d3" ){
            int index = mygame.user_click(this.transform);
            if (index != 0) {
                if (index > 2 || index < -2) this.transform.position = new Vector3(index,2.5f,0);
                else {
                    this.transform.position = new Vector3(index,1.6f,0);
                }
            }
        }
        // Debug.Log(this.transform.name);
    }  
}
