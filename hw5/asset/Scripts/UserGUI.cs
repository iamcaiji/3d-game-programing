using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    public int life = 10 ;                   //血量
    //每个GUI的style
    GUIStyle bold_style = new GUIStyle();
    GUIStyle score_style = new GUIStyle();
    GUIStyle text_style = new GUIStyle();
    GUIStyle over_style = new GUIStyle();
    private int high_score = 0;            //最高分
    private bool game_start = false;       //游戏开始
    private int help_count = 5;

    void Start ()
    {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }
	
	void OnGUI ()
    {
        bold_style.normal.textColor = new Color(1, 0, 0);
        bold_style.fontSize = 16;
        text_style.normal.textColor = new Color(0,0,0, 1);
        text_style.fontSize = 16;
        score_style.normal.textColor = new Color(1,0,1,1);
        score_style.fontSize = 16;
        over_style.normal.textColor = new Color(1, 0, 0);
        over_style.fontSize = 25;

        if (game_start)
        {
            //用户射击
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 pos = Input.mousePosition;
                action.Hit(pos);
            }

            GUI.Label(new Rect(10, 5, 50, 50), "Score:", text_style);
            GUI.Label(new Rect(65, 5, 50, 50), action.GetScore().ToString(), score_style);

            //显示当前血量
            GUI.Label(new Rect(10, 25, 50, 50), "HP:", text_style);
            GUI.Label(new Rect(65, 25, 50, 50), life.ToString(), bold_style);

            if (GUI.Button(new Rect(Screen.width - 150, 20, 100, 50), "Clear Srceen!!")){
                if (help_count > 0) {
                    action.ClearAll();
                    ReduceHelpCount();
                }
            }
            GUI.Label(new Rect(Screen.width / 2 - 25, 20, 100, 50), "Your chance for help: " + help_count.ToString(), text_style);
    
            //游戏结束
            if (life == 0)
            {
                high_score = high_score > action.GetScore() ? high_score : action.GetScore();
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 50), "游戏结束", over_style);
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 50, 50), "最高分:", text_style);
                GUI.Label(new Rect(Screen.width / 2 + 20, Screen.height / 2 - 50, 50, 50), high_score.ToString(), text_style);
                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 , 100, 50), "重新开始"))
                {
                    life = 6;
                    action.ReStart();
                    return;
                }
                action.GameOver();
            }
        }
        else
        {
            //GUI.Label(new Rect(Screen.width / 2 - 30, Screen.width / 2 - 350, 100, 100), "HelloUFO!", over_style);
            //GUI.Label(new Rect(Screen.width / 2 - 150, Screen.width / 2 - 220, 400, 100), "大量UFO出现，点击它们，即可消灭，快来加入战斗吧", text_style);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2-25, 100, 50), "游戏开始"))
            {
                game_start = true;
                action.BeginGame();
            }
        }
    }
    public void ReduceBlood()
    {
        if(life > 0)
            life--;
    }

    public void ReduceHelpCount(){
        if (help_count > 0) -- help_count;
    }
}
