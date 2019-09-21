using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PD;

namespace PD
{
    class Mygame
    {
        public static Mygame mygame; 
        // 1表示人在右边，0表示在和中间，-1表示人在左边
        public int _boat = 0, boat_seat = 0, left_seat = 0, right_seat = 6;
        public int p1 = 5, p2= 6, p3 = 7, d1 = 8, d2 = 9, d3 = 10;
        public Transform l = null, r = null;
        // public int[] leftnums = new int[6]{0,0,0,0,0,0};
        // public int[] rightnums = new int[6]{1,1,1,1,1,1};
        public void init(){
            if (mygame == null) mygame = new Mygame();
        }
        public static Mygame getMygame(){
            if (mygame == null) mygame = new Mygame();
            return mygame;
        }
        public bool init_boat(){
            if (_boat != 0) return false;
            _boat = 1;
            return true;
        }
        public int user_click(Transform tt){
            int[] nums = new int[6]{p1,p2,p3,d1,d2,d3};
            int index = 0;
            if (tt.name == "p1") index = 0;
            if (tt.name == "p2") index = 1;
            if (tt.name == "p3") index = 2;
            if (tt.name == "d1") index = 3;
            if (tt.name == "d2") index = 4;
            if (tt.name == "d3") index = 5;
            if (nums[index] > 4 && _boat == 1 && boat_seat < 2){
                if (boat_seat >= 2) return 0;
                else if (boat_seat == 1) {
                    boat_seat = 2;
                    right_seat --;
                    for (int i = 1; i <= 2; ++ i){
                        if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                            nums[index] = i;
                            if (i == 1) l = tt;
                            else r = tt;
                            break;
                        }
                    }
                    if (tt.name == "p1") p1 = nums[index];
                    if (tt.name == "p2") p2 = nums[index];
                    if (tt.name == "p3") p3 = nums[index];
                    if (tt.name == "d1") d1 = nums[index];
                    if (tt.name == "d2") d2 = nums[index];
                    if (tt.name == "d3") d3 = nums[index];
                    return nums[index]; 
                }
                else if (boat_seat == 0) {
                    boat_seat = 1;
                    for (int i = 1; i <= 2; ++ i){
                        if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                            nums[index] = i;
                            if (i == 1) l = tt;
                            else r = tt;
                            break;
                        }
                    }
                    right_seat --;
                    if (tt.name == "p1") p1 = nums[index];
                    if (tt.name == "p2") p2 = nums[index];
                    if (tt.name == "p3") p3 = nums[index];
                    if (tt.name == "d1") d1 = nums[index];
                    if (tt.name == "d2") d2 = nums[index];
                    if (tt.name == "d3") d3 = nums[index];
                    return nums[index]; 
                }
            }
            else if (nums[index] < -4 && _boat == -1 && boat_seat < 2){
                if (boat_seat >= 2) return 0;
                else if (boat_seat == 1) {
                    boat_seat = 2;
                    left_seat --;
                    for (int i = -2; i <= -1; ++ i){
                        if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                            nums[index] = i;
                            if (i == -2) l = tt;
                            else r = tt;
                            break;
                        }
                    }
                    if (tt.name == "p1") p1 = nums[index];
                    if (tt.name == "p2") p2 = nums[index];
                    if (tt.name == "p3") p3 = nums[index];
                    if (tt.name == "d1") d1 = nums[index];
                    if (tt.name == "d2") d2 = nums[index];
                    if (tt.name == "d3") d3 = nums[index];
                    return nums[index]; 
                }
                else if (boat_seat == 0) {
                    nums[index] = 0;
                    boat_seat = 1;
                    left_seat --;
                    for (int i = -2; i <= -1; ++ i){
                        if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                            nums[index] = i;
                            if (i == -2) l = tt;
                            else r = tt;
                            break;
                        }
                    }
                    if (tt.name == "p1") p1 = nums[index];
                    if (tt.name == "p2") p2 = nums[index];
                    if (tt.name == "p3") p3 = nums[index];
                    if (tt.name == "d1") d1 = nums[index];
                    if (tt.name == "d2") d2 = nums[index];
                    if (tt.name == "d3") d3 = nums[index];
                    return nums[index]; 
                }
            }
            else if (nums[index] < 4 && nums[index] > -4) {
                if (_boat == 1){
                    if (right_seat >= 6) return 0;
                    else {
                        right_seat ++;
                        //返回空位置
                        for (int i = 5; i <= 10; ++ i){
                            if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                                nums[index] = i;
                                break;
                            }
                        }
                        if (tt.name == "p1") p1 = nums[index];
                        if (tt.name == "p2") p2 = nums[index];
                        if (tt.name == "p3") p3 = nums[index];
                        if (tt.name == "d1") d1 = nums[index];
                        if (tt.name == "d2") d2 = nums[index];
                        if (tt.name == "d3") d3 = nums[index];
                        //位置改了之后才能判断船上哪个空了
                        for (int i = 1; i <= 2; ++ i){
                            if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                                if (i == 1) l = null;
                                else r = null;
                                break;
                            }
                        }
                        boat_seat --;
                        return nums[index];
                    }
                } 
                if (_boat == -1){
                    if (left_seat >= 6) return 0;
                    else {
                        left_seat ++;
                        //返回空位置
                        for (int i = -10; i <= -5; ++ i){
                            if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                                nums[index] = i;
                                break;
                            }
                        }
                        if (tt.name == "p1") p1 = nums[index];
                        if (tt.name == "p2") p2 = nums[index];
                        if (tt.name == "p3") p3 = nums[index];
                        if (tt.name == "d1") d1 = nums[index];
                        if (tt.name == "d2") d2 = nums[index];
                        if (tt.name == "d3") d3 = nums[index];
                        for (int i = -2; i <= -1; ++ i){
                            if (p1 != i && p2 != i && p3 != i && d1 != i && d2 != i && d3 != i){
                                if (i == -2) l = null;
                                else r = null;
                                break;
                            }
                        }
                        boat_seat --;
                        return nums[index];
                    }
                } 
            }
            return 0;
        }
        public void boat_r2l(Transform tt){
            if (boat_seat == 2){
                l.position = new Vector3(-2,1.6f,0);
                r.position = new Vector3(-1,1.6f,0);
                if (l.name == "p1") p1 = -2;
                if (l.name == "p2") p2 = -2;
                if (l.name == "p3") p3 = -2;
                if (l.name == "d1") d1 = -2;
                if (l.name == "d2") d2 = -2;
                if (l.name == "d3") d3 = -2;
                if (r.name == "p1") p1 = -1;
                if (r.name == "p2") p2 = -1;
                if (r.name == "p3") p3 = -1;
                if (r.name == "d1") d1 = -1;
                if (r.name == "d2") d2 = -1;
                if (r.name == "d3") d3 = -1;
            }
            if (boat_seat == 1){
                if (l != null) {
                    l.position = new Vector3(-2,1.6f,0);
                    if (l.name == "p1") p1 = -2;
                    if (l.name == "p2") p2 = -2;
                    if (l.name == "p3") p3 = -2;
                    if (l.name == "d1") d1 = -2;
                    if (l.name == "d2") d2 = -2;
                    if (l.name == "d3") d3 = -2;
                }
                if (r != null) {
                    r.position = new Vector3(-1,1.6f,0);
                    if (r.name == "p1") p1 = -1;
                    if (r.name == "p2") p2 = -1;
                    if (r.name == "p3") p3 = -1;
                    if (r.name == "d1") d1 = -1;
                    if (r.name == "d2") d2 = -1;
                    if (r.name == "d3") d3 = -1;
                }
            }
            tt.position = new Vector3(-2,1.1f,0);
            _boat = -1;
        }
        public void boat_l2r(Transform tt){
            if (boat_seat == 2){
                l.position = new Vector3(1,1.6f,0);
                r.position = new Vector3(2,1.6f,0);
                if (l.name == "p1") p1 = 1;
                if (l.name == "p2") p2 = 1;
                if (l.name == "p3") p3 = 1;
                if (l.name == "d1") d1 = 1;
                if (l.name == "d2") d2 = 1;
                if (l.name == "d3") d3 = 1;
                if (r.name == "p1") p1 = 2;
                if (r.name == "p2") p2 = 2;
                if (r.name == "p3") p3 = 2;
                if (r.name == "d1") d1 = 2;
                if (r.name == "d2") d2 = 2;
                if (r.name == "d3") d3 = 2;
            }
            if (boat_seat == 1){
                if (l != null) {
                    l.position = new Vector3(1,1.6f,0);
                    if (l.name == "p1") p1 = 1;
                    if (l.name == "p2") p2 = 1;
                    if (l.name == "p3") p3 = 1;
                    if (l.name == "d1") d1 = 1;
                    if (l.name == "d2") d2 = 1;
                    if (l.name == "d3") d3 = 1;
                }
                if (r != null) {
                    r.position = new Vector3(2,1.6f,0);
                    if (r.name == "p1") p1 = 2;
                    if (r.name == "p2") p2 = 2;
                    if (r.name == "p3") p3 = 2;
                    if (r.name == "d1") d1 = 2;
                    if (r.name == "d2") d2 = 2;
                    if (r.name == "d3") d3 = 2;
                }
            }
            tt.position = new Vector3(2,1.1f,0);
            _boat = 1;
        }

        public bool is_gameover(){
           int[] nums = new int[6]{p1,p2,p3,d1,d2,d3};
           int demon = 0, priest = 0;
            if (_boat == 1) {
                for (int i = 0; i < 6; ++ i) {
                    if (nums[i] < -4){
                        if (i < 3) ++ priest;
                        else ++ demon;
                    }
                }
            }
            if (_boat == -1) {
                for (int i = 0; i < 6; ++ i) {
                    if (nums[i] > 4){
                        if (i < 3) ++ priest;
                        else ++ demon;
                    }
                }
            }
            if (demon > priest && priest != 0) return true;
            else return false;
        }

        public bool is_win(){
            int[] nums = new int[6]{p1,p2,p3,d1,d2,d3};
            for (int i = 0; i < 6; ++ i){
                if (nums[i] > -4) return false;
            }
            return true;
        }

    }
}

public class Model : MonoBehaviour
{
    public GameObject left_plane, right_plane, down_plane, river, boat;
    public MeshRenderer river_color;

    //为游戏对象添加事件
    void AddObjectClickEvent(GameObject itemObject) {
        var box = itemObject.GetComponent<BoxCollider>();
        if (box == null)
        {
            box = itemObject.AddComponent<BoxCollider>();
        }
        
        // ThreeD_Object为3D物体挂载的脚本
        var item = itemObject.GetComponent<CubeItem>();
        if (item == null)
        {
            item = itemObject.AddComponent<CubeItem>();
        }

        var meshrenderer = itemObject.GetComponent<MeshRenderer>();
        if (meshrenderer == null)
        {
            meshrenderer = itemObject.AddComponent<MeshRenderer>();
        }
            
        EventTrigger trigger = itemObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = itemObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        UnityEngine.Events.UnityAction<BaseEventData> click = 
            new UnityEngine.Events.UnityAction<BaseEventData>(item.OnClickCubeItem);
        entry.callback.AddListener(click);

        trigger.triggers.Clear();
        trigger.triggers.Add(entry);
    }

    //创建牧师和恶魔的游戏对象
    void creat_people(){
        for (int i = 0; i < 3; ++ i){
            GameObject p = GameObject.CreatePrimitive(PrimitiveType.Cube);
            p.transform.position = new Vector3(5 + i, 2.5f, 0);
            p.transform.localScale = new Vector3(0.5f,1,0.5f);
            p.GetComponent<Renderer>().material.color = Color.red;
            p.transform.name = "p" + (i + 1).ToString();
            AddObjectClickEvent(p);
        }
        for (int i = 0; i < 3; ++ i){
            GameObject d = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            d.transform.position = new Vector3(8 + i, 2.5f, 0);
            d.transform.localScale = new Vector3(0.5f,1,0.5f);
            d.GetComponent<Renderer>().material.color = Color.yellow;
            d.transform.name = "d" + (i + 1).ToString();
            AddObjectClickEvent(d);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //创建所有的游戏对象
        left_plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        left_plane.transform.position = new Vector3(-8, 0, 0);
        left_plane.transform.localScale = new Vector3(8,4,4);
        left_plane.GetComponent<Renderer>().material.color = Color.gray; 

        right_plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        right_plane.transform.position = new Vector3(8, 0, 0);
        right_plane.transform.localScale = new Vector3(8,4,4);
        right_plane.GetComponent<Renderer>().material.color = Color.gray;

        down_plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        down_plane.transform.position = new Vector3(0, -1, 0);
        down_plane.transform.localScale = new Vector3(8,2,4);
        down_plane.GetComponent<Renderer>().material.color = Color.gray;

        river = GameObject.CreatePrimitive(PrimitiveType.Cube);
        river.transform.position = new Vector3(0, 0.5f, 0);
        river.transform.localScale = new Vector3(8,1,4);
        river.GetComponent<Renderer>().material.color = Color.blue;
        
        creat_people();

        boat = GameObject.CreatePrimitive(PrimitiveType.Cube);
        boat.transform.position = new Vector3(0, 1.1f, 0);
        boat.transform.localScale = new Vector3(4,0.2f,3);
        boat.GetComponent<Renderer>().material.color = Color.HSVToRGB(100, 127, 65);
        boat.transform.name = "boat";
        AddObjectClickEvent(boat);
    }

    // private void OnGUI() {
    //     if (GUI.Button(new Rect(250, 100, 80, 40), "ReStart!")) {
   
    //     }    
    // }
}
