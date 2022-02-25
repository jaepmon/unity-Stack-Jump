using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject comboEffect;
    public GameObject settingUI;
    public Text textStart;
    public Text textScore;
    public bool isGameStart = false;
    public bool isSettingUI = false;
    public int increaseScore = 10;
    public int comboBonusScore = 10;
    public int comboCount;
    int currentScore = 0;
    BacktoObjectPool theBacktoObjectPool;
    CameraMoving theCameraMoving;
    PlateSpawn ps;
    Player thePlayer;
    Plate thePlate;

    void Awake()
    {
        theBacktoObjectPool = FindObjectOfType<BacktoObjectPool>();
        theCameraMoving = FindObjectOfType<CameraMoving>();
        thePlayer = FindObjectOfType<Player>();
        thePlate = FindObjectOfType<Plate>();
        ps = FindObjectOfType<PlateSpawn>();
        //SetResolution();
    }
    //public void SetResolution()
    //{
    //    int setWidth = 720; // 사용자 설정 너비
    //    int setHeight = 1280; // 사용자 설정 높이

    //    int deviceWidth = Screen.width; // 기기 너비 저장
    //    int deviceHeight = Screen.height; // 기기 높이 저장

    //    Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), false); // SetResolution 함수 제대로 사용하기

    //    if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
    //    {
    //        float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
    //        Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
    //    }
    //    else // 게임의 해상도 비가 더 큰 경우
    //    {
    //        float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
    //        Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
    //    }
    //}
    public void OnClickStart()
    {

        isGameStart = isSettingUI ? false : true;

        if(isGameStart)
        {
            ps.CreatePlate();

            textStart.gameObject.SetActive(false);
        }
    }
    public void OnClickJump()
    {
        thePlayer.Jump();
        theBacktoObjectPool.MoveLine();
    }
    public void OnClickSetting()
    {
        isSettingUI = true;
        settingUI.SetActive(true);
    }
    public void OnClickOutSetting()
    {
        isSettingUI = false;
        settingUI.SetActive(false);
    }
    public void Init()
    {
        theBacktoObjectPool.Init();
        theCameraMoving.Init();
        thePlayer.Init();
        ps.Init();
        currentScore = 0;
        comboCount = 0;
        SetScore(currentScore);
        textStart.gameObject.SetActive(true);
    }
    public void ComboSuccess()
    {
        ++comboCount;

        if (comboCount > 2)
        {
            ComboEffect();
        }
    }
    public void ComboFail()
    {
        comboCount = 0;
    }
    public void ComboEffect()
    {
        GameObject createComboEf = Instantiate(comboEffect, thePlayer.transform.position, thePlayer.transform.rotation);
        Destroy(createComboEf, 0.3f);
    }
    public void AddScore()
    {
        ComboSuccess();

        int bonusComboScore = (comboCount / 2) * comboBonusScore;

        int totalIncreaseScore = increaseScore + bonusComboScore;

        currentScore += totalIncreaseScore;

        SetScore(currentScore);
    }
    public void SetScore(int score)
    {
        textScore.text = string.Format("{0:n0}", score);
    }
}
