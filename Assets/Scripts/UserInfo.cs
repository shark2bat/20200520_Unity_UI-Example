using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 매핑 클래스
public class MissionInfo
{
    public int id;
    public int grade;
    public int progressCount;
    public bool isComplete;
    public bool isRewarded;
}

// 매핑 클래스
public class RewardInfo
{
    public int id;
    public int amount;
}

// 매핑 클래스를 멤버변수로 가지는 UserInfo
// InfoManager의 Save OR Load의 대상이 된다.
public class UserInfo
{
    public Dictionary<int, MissionInfo> dicMssionInfos;
    public Dictionary<int, RewardInfo> dicRewardInfos;

    public UserInfo()
    {
        this.dicMssionInfos = new Dictionary<int, MissionInfo>();
        this.dicRewardInfos = new Dictionary<int, RewardInfo>();
    }
}