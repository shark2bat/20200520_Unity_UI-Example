using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup_Mission : MonoBehaviour
{
    public GameObject scrollContents;
    public Button btnClose;

    public void Start()
    {
        this.btnClose.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });

        // 데이터 매니저 인스턴스화 및 데이터 로드
        var dataManager = DataManager.GetInstance();
        dataManager.LoadAllDatas();

        // 인포 매니저 인스턴스화 및 인포 로드
        var infoManager = InfoManager.Getinstance();
        infoManager.LoadUserInfo();

        // 데이터 매니저에서 미션 데이터 전부 가져오기.
        var missionDatas = dataManager.GetMissionDatasAll();

        for (int i = 0; i < missionDatas.Count; i++)
        {
            // 스크롤에 들어갈 리스트 아이템을 불러온다.
            var missionContent = Resources.Load<UIListItem_Mission>("Prefabs/UIListItem_Mission");
            var missionContentGo = Instantiate(missionContent) as UIListItem_Mission;
            var nowMissionData = missionDatas[i + 100];
            var nowMissionInfo = infoManager.UserInfo.dicMssionInfos[i + 100];

            // Data ---> 아이콘, 이름, 보상 아이콘, 보상 수량
            // Info ---> 진행도, 진행도 및 성공 여부, 보상 수령 여부, 미션 단계

            // 해당 미션 번호에 맞는 아이콘 활성화, 이름 할당, 보상아이콘 설정, 보상 수량 설정
            // 아이콘 활성화
            missionContentGo.icons[i].gameObject.SetActive(true);
            // 미션 이름 할당
            string fullDesc = string.Format(nowMissionData.desc, nowMissionData.goal);
            missionContentGo.textName.text = fullDesc;
            // 보상 아이콘 활성화
            missionContentGo.arrUIBinder_MissionRewardIcons[
                nowMissionData.reward_id].gameObject.SetActive(true);
            // 보상 수량 할당
            missionContentGo.arrUIBinder_MissionRewardIcons[
               nowMissionData.reward_id].reward_amount.text = nowMissionData.reward_amount.ToString();
            
            // 성공여부 판단 --> 보상 버튼 부분 판단.
            // 미션 성공하지 않은 경우
            if (nowMissionInfo.isComplete == false)
            {
                // p.s. for 문 사용해도 가능하나 3개라서 그냥 작성함...
                missionContentGo.arrBtns[0].SetActive(true);
                missionContentGo.arrBtns[1].SetActive(false);
                missionContentGo.arrBtns[2].SetActive(false);
            }
            // 미션성공, 보상받기 이전
            else if (nowMissionInfo.isComplete == true && nowMissionInfo.isRewarded == false)
            {
                missionContentGo.arrBtns[0].SetActive(false);
                missionContentGo.arrBtns[1].SetActive(true);
                missionContentGo.arrBtns[2].SetActive(false);
            }
            // 미션성공, 보상받은 이후
            else if (nowMissionInfo.isComplete == true && nowMissionInfo.isRewarded == true)
            {
                missionContentGo.arrBtns[0].SetActive(false);
                missionContentGo.arrBtns[1].SetActive(false);
                missionContentGo.arrBtns[2].SetActive(true);
            }

            // 미션 슬라이더 진행도 표시하기.
            float progressPercent = (float)nowMissionInfo.progressCount / (float)nowMissionData.goal;
            missionContentGo.sliderProgress.value = progressPercent;
            
            // 미션 단계 표시
            for(int grade = 0; grade < nowMissionInfo.grade; grade++)
            {
                missionContentGo.stars[grade].gameObject.SetActive(true);
            }

            // 모든 정보를 불러온 미션항목들을
            // 스크롤 콘텐츠의 자식으로 설정한다.
            missionContentGo.gameObject.transform.SetParent(this.scrollContents.transform, false);
        }

    }

}
