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
    }
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
