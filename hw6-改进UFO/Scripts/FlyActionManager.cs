using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyActionManager : SSActionManager
{
                        //飞碟飞行的动作
    public FirstController scene_controller;             //当前场景的场景控制器
    public int flags = 0; // 表示这个飞盘是运动学的还是动力学的

    protected void Start()
    {
        scene_controller = (FirstController)SSDirector.GetInstance().CurrentScenceController;
        scene_controller.action_manager = this;     
    }
    //飞碟运动学飞行
    public void UFOFly1(GameObject disk, float angle, float power)
    {
        UFOFlyAction1 fly = UFOFlyAction1.GetSSAction(disk.GetComponent<DiskData>().direction, angle, power);
            this.RunAction(disk, fly, this);
    }
    public void UFOFly2(GameObject disk, float angle, float power)
    {
        UFOFlyAction2 fly = UFOFlyAction2.GetSSAction(disk.GetComponent<DiskData>().direction, angle, power);
            this.RunAction(disk, fly, this);
    }
}
