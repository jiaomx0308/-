using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    static CursorManager instance;

    
    public static CursorManager Instance {
        get {
            if (instance == null)
            {
                var go = new GameObject();
                instance = go.AddComponent<CursorManager>();
                DontDestroyOnLoad(go);
                go.name = "CursorManager";
            }
            return instance;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            //进入GM模式
            //...
        }

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //可以加入手机上的操作
        //...

        //发送事件
        //...
    }
}
