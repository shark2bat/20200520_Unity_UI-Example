using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 바인딩용 클래스
// 미션 각 항목에 컴포넌트로 부착되어있다.
public class UIListItem_Mission : MonoBehaviour
{
    public GameObject[] icons; // 미션 아이콘
    public GameObject[] stars; // 별
    public Text textName; // 미션 이름 Desc
    public Slider sliderProgress; // 미션 진행도 게이지
    public UIBinder_MissionRewardIcon[] arrUIBinder_MissionRewardIcons;
    public Button btnClaim;
    public GameObject[] arrBtns; // 미션 완료 전, 미션 완료 및 보상받은 후 보여줄 이미지.
}
