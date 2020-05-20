using shark2bat.ui.title.binder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    public Button btnStart;
    public UIBinder_BtnMission uiBinderBtnMission;
    public UIPopup_Mission uiPopup_Mission;
    
    public void Init()
    {
        this.btnStart.onClick.AddListener(() =>
        {
            Debug.LogFormat("시작 게임");
        });

        this.uiBinderBtnMission.btn.onClick.AddListener(() =>
        {
            Debug.LogFormat("팝업 미션 활성화");
            this.uiPopup_Mission.gameObject.SetActive(true);
        });
    }
}
