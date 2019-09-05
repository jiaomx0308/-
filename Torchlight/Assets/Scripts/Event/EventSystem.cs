using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemEvent
{
    public enum EventType
    {
        PlayerEnterWorld,   //我方玩家初始化结束,进入世界
        PlayerLeaveWorld, //离开世界

        UnitHP,  //单位HP变换
        UnitMP,  //单位MP变换
        UnitMaxHP, //单位MaxHP变换
        UnitMaxMP, //单位MaxMP变换

        UnitExp,  //经验变换
        UnitFaceImage,  //面部变换

        UnityDead, //角色死亡


        OpenItemCoffer, //打开背包面板
        PackageItemChanged, //背包物品变化
        UpdateItemCoffer, //更新物品
        UpdateDetailUI,


        ShowSuperToolTip, //显示tips面板
        UpdateSuperTip, //更新tip面板

        DebugMessage,

        CharEquipChanged, //某个角色的装备更新通知NpcEquipment



        RefreshEquip,  //背包界面更新装备ICON

        MeshShown,//显示背包里面的人物模型
        MeshHide,//Hide Model For UI

        UnitMoney,//五种货币变化了

        OpenAttr,//打开属性面板
        OpenComposeItem, //打开装备强化面板
        ComposeOver,//装备合成结束

        OpenCopyUI,//打开副本UI
        UpdateCopy,

        OpenCopyTip, //打开或者更新副本Tip界面

        ChangeScene, //切换场景关闭所有的UI  //PlayerLeaveWorld, 
        EnterScene,

        UpdateSkill,//Open Skill Panel 更新技能面板或者技能按钮
        MovePlayer,

        MonsterDead,

        OpenShortCut,
        UpdateShortCut,

        OpenMall,

        TryEquip, //FakeUI 对象尝试穿上新的时装 NpcEquipment 处理该事件

        UpdateTeam,
        UpdateTeamInfo,

        UpdateCopyList,
        SelectCopy,

        TeamStateChange,
        UpdateShenPi,


        UpdateLogin,

        UpdateSelectChar,

        OkEnter,//进入某个场景

        NewChatMsg,
        OpenAchievement,

        UpdateVip,
        openVip,


        EventTrigger = 10000,//动画的Hit事件
        EventStart = 10001,
        SpawnParticle = 10002,
        EventMissileDie = 10003,
        EventEnd = 10004,
        AnimationOver = 10005, //Skill AnimationOver


        UpdateTask,
        openTask,

        PlayerDead,

        UpdateCharacterCreateUI,
        CreateSuccess, //创建角色成功

        UpdateChat, //更新聊天窗口

        DeadExp, //杀死怪物获取到经验

        ShowWeaponTrail,
        HideWeaponTrail,

        ShakeCamera,
        ShakeCameraStart,
        ShakeCameraEnd,

        UpdatePlayerData,//Global Used To Notify MY Data Change
        UpdateMainUI, //

        KillAllMonster,
        ReConnect,

        ShowStory,
        EndStory,

        EnterNextZone,

        BossSpawn,
        SpeakOver,//对话结束
        BossDead,

        NpcDead,
        LevelFinish,
        GameOver,

        Combat,
        OnHit,

        WolfCall,
        HuiShuLeaderDead,
        MeDead,

        EnterSafePoint,
        ExitSafePoint,

        HitTarget, //击中目标一次
        TeamColor,
        IsMaster,
    }

    public int localID = -1;
    public EventType type;
    public string strArg;
    public int intArg0 = -1;
    public int intArg1 = 0;
    public float floatArg = 0;
    public bool boolArg = false;

    public EventSystemEvent(EventType t)
    {
        type = t;
    }

    public EventSystemEvent()
    {

    }

    public delegate void EventDel(EventSystemEvent evt);

    public interface IEventDispatch
    {
        void RegisterEvent(string evtName, EventDel callBack);

        void DropListener(string evtName, EventDel callBack);

        void PushEvent(EventSystemEvent evt);
    }

    public abstract class IEventHandler
    {
        protected List<EventType> regEvent;
        public void RegEvent()
        {
            if (regEvent != null)
            {
                foreach (EventType e in regEvent)
                {
                    EventSystem.RegisterEvent(e, OnEvent);
                }
            }
        }
        public abstract void Init();
        public abstract void OnEvent(EventSystemEvent evt);
    }

    public class EventSystem
    {
        static int LoaclCoff = 100000;
        public static List<IEventHandler> eventHandlers = new List<IEventHandler>();

        internal static void RegisterEvent(EventType e, EventDel onEvent)
        {
            throw new NotImplementedException();
        }
    }
}
