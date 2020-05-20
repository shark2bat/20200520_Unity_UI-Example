using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 인포매니저 클래스 , 싱글턴 유형
public class InfoManager
{
    private static InfoManager instance;
    public UserInfo UserInfo { get; set; }

    private InfoManager()
    {
        this.UserInfo = new UserInfo();   
    }

    public static InfoManager Getinstance()
    {
        if(InfoManager.instance == null)
        {
            InfoManager.instance = new InfoManager();
        }

        return InfoManager.instance;
    }

    // 유저 정보를 불러오는 메서드
    // 유저 정보에 대한 파일이 없다면 생성한다.
    public void LoadUserInfo()
    {
        string fullpathUserInfo = Application.persistentDataPath + "/user_info.json";
        if (File.Exists(fullpathUserInfo))
        {
            var textUserInfo = File.ReadAllText(fullpathUserInfo);
            this.UserInfo = JsonConvert.DeserializeObject<UserInfo>(textUserInfo);
            Debug.LogFormat("UserInfo::LoadInfos");
        }
        else
        {
            var dataManager = DataManager.GetInstance();
            var infoManager = InfoManager.Getinstance();

            var dicMissionDatas = dataManager.GetMissionDatasAll();
            var dicRewardDatas = dataManager.GetRewardDatasAll();

            foreach (var pair in dicMissionDatas)
            {
                var data = pair.Value;
                MissionInfo missionInfo = new MissionInfo();
                missionInfo.id = data.id;
                infoManager.UserInfo.dicMssionInfos.Add(missionInfo.id, missionInfo);
            }
            foreach (var pair in dicRewardDatas)
            {
                var data = pair.Value;
                RewardInfo rewardInfo = new RewardInfo();
                rewardInfo.id = data.id;
                infoManager.UserInfo.dicRewardInfos.Add(rewardInfo.id, rewardInfo);
            }

            SaveUserInfo();
        }
    }

    // 유저 정보를 저장하는 메서드
    public void SaveUserInfo()
    {
        string fullpathUserInfo = Application.persistentDataPath + "/user_info.json";
        var infoManager = InfoManager.Getinstance();
        File.WriteAllText(fullpathUserInfo, JsonConvert.SerializeObject(infoManager.UserInfo));
        Debug.LogFormat("UserInfo::SetNewInfo");
    }
}
