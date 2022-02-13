using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text textStart;
    public Text textScore;
    public int score;
    public int comboCount;
    public bool isGameStart = false;
    public GameObject comboEffect;
    CameraMoving theCameraMoving;
    Player thePlayer;
    Plate thePlate;
    BacktoObjectPool theBacktoObjectPool;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        theCameraMoving = FindObjectOfType<CameraMoving>();
        thePlayer = FindObjectOfType<Player>();
        thePlate = FindObjectOfType<Plate>();
        theBacktoObjectPool = FindObjectOfType<BacktoObjectPool>();
    }
    public void OnClickStart()
    {
        isGameStart = true;

        PlateSpawn.instance.CreatePlate();

        textStart.gameObject.SetActive(false);
        
    }

    public void OnClickJump()
    {
        thePlayer.Jump();
        theBacktoObjectPool.MoveLine();
    }

    public void Init()
    {
        theBacktoObjectPool.Init();
        theCameraMoving.Init();
        score = 0;
        SetScore(score);
        PlateSpawn.instance.Init();
        thePlayer.Init();
        textStart.gameObject.SetActive(true);
    }

    public void SetScore(int score)
    {
        textScore.text = string.Format("{0:n0}", score);
    }

    public void AddScore()
    {
        score++;
        SetScore(score);
    }

    public void ComboSuccess()
    {
        comboCount++;
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
}
