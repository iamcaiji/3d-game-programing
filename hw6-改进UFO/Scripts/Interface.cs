﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneController
{
    //加载场景
    void LoadResources();                                  
}

public interface IUserAction                              
{
    void Hit(Vector3 pos);
    int GetScore();
    void GameOver();
    void ReStart();
    void BeginGame();
    void ClearAll();
    void setAction(int a);
}
public enum SSActionEventType : int { Started, Competeted }
public interface ISSActionCallback
{
    void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0, string strParam = null, Object objectParam = null);
}