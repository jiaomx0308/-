using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KBEngine
{

    /// <summary>
    /// 服务器对象, ID Assigned by Server
    /// </summary>
    public class KBPlayer
    {
        public int ID = -1;
    }

    /// <summary>
    /// 服务器对象下面的衍生的本地对象或服务器对象
    /// 如单人副本中的怪物,为本地对象
    /// 多人副本中的怪物为服务器对象
    /// 
    /// 我的服务器对象对应多个本地对象 (玩家实体和怪物实体)
    /// </summary>
    public class KBViewID   //一般当做ServerID
    {
        KBPlayer internalPlayer;
        public int ViewID;

        public KBPlayer owner { get { return internalPlayer; }  }

        public KBViewID(int id, KBPlayer player)
        {
            ViewID = id;
            internalPlayer = player;
        }
    }


    /// <summary>
    /// 带事件处理程序的MonoBehaviour
    /// </summary>
    public class MonoBehaviour : UnityEngine.MonoBehaviour
    {
       // protected List<>
    }



    public class KBNetworkView : MonoBehaviour
    {
        static int globleLocalID = 0;  //该类的静态ID
        int localID = -1;
        KBViewID ID = new KBViewID(0, null);
        public bool isPlayer = true;  //是否是玩家


        public int LocalID
        {
            get
            {
                if (localID == -1)
                {
                    localID = globleLocalID++;
                }
                return localID;
            }

            set
            {
                localID = value;
            }
        }

        /// <summary>
        /// 玩家返回玩家ID
        /// 怪物返回ViewID
        /// </summary>
        public int GetServerID()
        {
            if (ID.owner == null)
            {
                Debug.Log("KBNetworkView:: not net connection");
                return -1;
            }

            if (!isPlayer)
            {
                return ID.ViewID;
            }
            return ID.owner.ID;  //返回ServerID
        }

        public KBViewID GetID()
        {
            return ID;
        }

        public void SetID(KBViewID id)
        {
            ID = id;
        }

        public int GetViewID()
        {
            return ID.ViewID;
        }

        public bool IsMe
        {
            get
            {
                return localID == ObjectManager.Instance.GetMyLocalID();
            }
        }

        /// <summary>
        /// 是否是我可以控制的对象
        /// 网络状态下 == myplayer,如果是怪物,还需要判断是否是Master才行
        /// </summary>
        public bool IsMine()
        {
            if (ID.owner == null)
            {
                Debug.Log("KBNetworkView:: No NetworkConnect Init Player Is Mine");
                return true;
            }

            var isMine = ID.owner == ObjectManager.Instance.myPlayer;

            if (!isPlayer)
            {
                if (isMine && NetworkUtil.IsMaster())
                {
                    return true;
                }
                return false;
            }
            return isMine;
        }
    }
}

