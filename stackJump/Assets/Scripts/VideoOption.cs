using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    public Dropdown dropDown;
    public int valueNum;

    List<Resolution> resolutions = new List<Resolution>();
    
    void OnEnable()
    {
        ShowDropdown();
    }
    //public void SetResolution()
    //{
    //    int setWidth = 1080; // 사용자 설정 너비
    //    int setHeight = 1920; // 사용자 설정 높이

    //    int deviceWidth = Screen.width; // 기기 너비 저장
    //    int deviceHeight = Screen.height; // 기기 높이 저장

    //    Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

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

public void ShowDropdown()
    {
        for(int i = 0; i < Screen.resolutions.Length; i++)
        {
            if(Screen.resolutions[i].refreshRate == 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        
        dropDown.options.Clear();
        int optionNum = 0;
        foreach(Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height;
            dropDown.options.Add(option);

            if(item.width == Screen.width && item.height == Screen.height)
            {
                dropDown.value = optionNum;
            }
            optionNum++;
        }
        dropDown.RefreshShownValue();
    }

    public void DropboxOptionChange(int num)
    {
        valueNum = num;
    }

    public void OKBtnClick()
    {
        Screen.SetResolution(resolutions[valueNum].width,
                             resolutions[valueNum].height, false);
    }
}
