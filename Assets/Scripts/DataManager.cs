using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 매핑클래스
public class RewardData 
{
    public int id;
    public string name;
    public string icon_res_name;
}

// 매핑클래스
public class MissionData 
{
    public int id;
    public string name;
    public string icon_res_name;
    public string desc;
    public int goal;
    public int reward_id;
    public int reward_amount;
}

// 데이터 매니저 클래스, 싱글턴 유형
public class DataManager
{
    private static DataManager instance;
    private Dictionary<int, RewardData> dicRewardDatas;
    private Dictionary<int, MissionData> dicMissionDatas;

    private DataManager()
    {
        this.dicMissionDatas = new Dictionary<int, MissionData>();
        this.dicRewardDatas = new Dictionary<int, RewardData>();
    }

    public static DataManager GetInstance()
    {
        if (DataManager.instance == null)
        {
            DataManager.instance = new DataManager();
        }

        return DataManager.instance;
    }

    public void LoadAllDatas()
    {
        TextAsset textMission = Resources.Load("Datas/mission_data") as TextAsset;
        TextAsset textReward = Resources.Load("Datas/reward_data") as TextAsset;

        MissionData[] arrMissionDatas = JsonConvert.DeserializeObject<MissionData[]>(textMission.text);
        var arrRewardDatas = JsonConvert.DeserializeObject<RewardData[]>(textReward.text);

        this.dicMissionDatas = arrMissionDatas.ToDictionary(x => x.id);
        this.dicRewardDatas = arrRewardDatas.ToDictionary(x => x.id);
    }

    public void ShowMissions()
    {
        foreach (var pair in this.dicMissionDatas)
        {
            var data = pair.Value;
            string fulldesc = string.Format(data.desc,
                        string.Format("{0:#,##0}", data.goal));
            Debug.LogFormat("id:{0}, desc: {1}, reward: {2} x {3}", data.id, fulldesc,
                this.dicRewardDatas[data.reward_id].name, data.reward_amount);
        }
    }

    public MissionData GetMissionDataById(int id)
    {
        return this.dicMissionDatas[id];
    }

    public RewardData GetRewardDataById(int id)
    {
        return this.dicRewardDatas[id];
    }

    public Dictionary<int,MissionData> GetMissionDatasAll()
    {
        return this.dicMissionDatas;
    }
    public Dictionary<int, RewardData> GetRewardDatasAll()
    {
        return this.dicRewardDatas;
    }

}
