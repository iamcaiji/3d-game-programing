using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PD;

namespace PD
{
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
    
    public class Mygame
    {
        public static Mygame mygame; 
        //object names and positions
        public string[] object_names = new string[6]{"p1", "p2", "p3", "d1", "d2", "d3"};
        public int[] nums = new int[6]{5,6,7,8,9,10};
        // 1表示人在右边，0表示在和中间，-1表示人在左边
        public int _boat = 0, boat_seat = 0, left_seat = 0, right_seat = 6;
        // public int p1 = 5, p2= 6, p3 = 7, d1 = 8, d2 = 9, d3 = 10;
        public Transform l = null, r = null;
        //mark the boat left seat and right seat
        public bool boat_left_empty = true, boat_right_empty = true;
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

        public int get_index_by_name(string str){
            for (int i = 0; i < 6; ++ i){
                if (str == object_names[i])
                    return i;
            }
            return -1;
        }

        public int get_empty_index_of_right(){
            for (int i = 5; i <= 10; ++ i){
                bool is_empty = true;
                for (int j = 0; j < 6; ++ j){
                    if (nums[j] == i) {
                        is_empty = false; 
                        break;
                    }
                }
                if (is_empty) return i;
            }
            return -1;
        }

        public int get_empty_index_of_left(){
            for (int i = -5; i >= -10; -- i){
                bool is_empty = true;
                for (int j = 0; j < 6; ++ j){
                    if (nums[j] == i) {
                        is_empty = false; 
                        break;
                    }
                }
                if (is_empty) return i;
            }
            return -1;
        }
        // 用户点击之后返回点击的对象的Transform,然后进行这个对象的逻辑操作，判断怎么运动以及是否能运动
        public int user_click(Transform tt){
            int index = get_index_by_name(tt.name);
            if (nums[index] > 4 && _boat == 1){
                if (boat_seat >= 2) return 0;
                else {
                    if (boat_left_empty) {
                        boat_seat ++;
                        right_seat --;
                        l = tt;
                        boat_left_empty = false;
                        nums[index] = 1;
                    }
                    else if (boat_right_empty){
                        boat_seat ++;
                        right_seat --;
                        r = tt;
                        boat_right_empty = false;
                        nums[index] = 2;
                    }
                    else return 0;
                    return nums[index]; 
                }
            }
            else if (nums[index] < -4 && _boat == -1){
                if (boat_seat >= 2) return 0;
                else {
                    if (boat_left_empty) {
                        boat_seat ++;
                        left_seat --;
                        l = tt;
                        boat_left_empty = false;
                        nums[index] = -2;
                    }
                    else if (boat_right_empty){
                        boat_seat ++;
                        left_seat --;
                        r = tt;
                        boat_right_empty = false;
                        nums[index] = -1;
                    }
                    else return 0;
                    return nums[index]; 
                }
            }
            else if (nums[index] < 4 && nums[index] > -4) {
                if (_boat == 1){
                    if (right_seat >= 6) return 0;
                    else {
                        right_seat ++;
                        //返回空位置
                        //位置改了之后才能判断船上哪个空了
                        if (nums[get_index_by_name(tt.name)] == 1) boat_left_empty = true;
                        else if (nums[get_index_by_name(tt.name)] == 2) boat_right_empty = true;
                        boat_seat --;  
                        nums[index] = get_empty_index_of_right();
                        return nums[index];
                    }
                } 
                if (_boat == -1){
                    if (left_seat >= 6) return 0;
                    else {
                        left_seat ++;
                        //位置改了之后才能判断船上哪个空了
                        if (nums[get_index_by_name(tt.name)] == -2) boat_left_empty = true;
                        else if (nums[get_index_by_name(tt.name)] == -1) boat_right_empty = true;
                        boat_seat --;
                        nums[index] = get_empty_index_of_left();
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
                nums[get_index_by_name(l.name)] = -2;
                nums[get_index_by_name(r.name)] = -1;
                tt.position = new Vector3(-2,1.1f,0);
                _boat = -1;
            }
            if (boat_seat == 1){
                if (!boat_left_empty) {
                    l.position = new Vector3(-2,1.6f,0);
                    nums[get_index_by_name(l.name)] = -2;
        
                }
                if (!boat_right_empty) {
                    r.position = new Vector3(-1,1.6f,0);
                    nums[get_index_by_name(r.name)] = -1;
                }
                tt.position = new Vector3(-2,1.1f,0);
                _boat = -1;
            }
        }
        public void boat_l2r(Transform tt){
            if (boat_seat == 2){
                l.position = new Vector3(1,1.6f,0);
                r.position = new Vector3(2,1.6f,0);
                nums[get_index_by_name(l.name)] = 1;
                nums[get_index_by_name(r.name)] = 2;
                tt.position = new Vector3(2,1.1f,0);
                _boat = 1;
            }
            if (boat_seat == 1){ 
                if (!boat_left_empty) {
                    l.position = new Vector3(1,1.6f,0);
                    nums[get_index_by_name(l.name)] = 1;
        
                }
                if (!boat_right_empty) {
                    r.position = new Vector3(2,1.6f,0);
                    nums[get_index_by_name(r.name)] = 2;
                }
                tt.position = new Vector3(2,1.1f,0);
                _boat = 1;
            }
        }

        public bool is_gameover(){
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
