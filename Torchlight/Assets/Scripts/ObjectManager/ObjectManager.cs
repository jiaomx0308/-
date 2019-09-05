using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance;
    public KBEngine.KBPlayer myPlayer;

    Dictionary<int, GameObject> fakeObjects = new Dictionary<int, GameObject>();

    /// <summary>
    /// 玩家服务器ID -> 忘记实体
    /// localID  PlayerID
    /// </summary>
    public Dictionary<int, KBEngine.KBPlayer> Actors = new Dictionary<int, KBEngine.KBPlayer>();
    List<KBEngine.KBNetworkView> photonViewList = new List<KBEngine.KBNetworkView>();

    public List<KBEngine.KBNetworkView> GetNewView()
    {
        return photonViewList;
    }

    public GameObject  GetPlayer()
    {
        if (myPlayer != null)
        {
            var vi = GetPlayerOrMonsterNetView(myPlayer.ID);
            if (vi != null)
                return vi.gameObject;
        }
        return null;
    }

    private KBEngine.KBNetworkView GetPlayerOrMonsterNetView(int iD)
    {
        foreach (KBEngine.KBNetworkView view in photonViewList)
        {
            if (view != null && view.GetServerID() == iD)
                return view;
        }

        return null;
    }

    internal int GetMyLocalID()
    {
        if (myPlayer != null)
        {
            var view = GetPlayerOrMonsterNetView(myPlayer.ID);
            if (view != null)
            {
                return view.LocalID;
            }
        }
        return -1;
    }
}
