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
    //    int setWidth = 1080; // ����� ���� �ʺ�
    //    int setHeight = 1920; // ����� ���� ����

    //    int deviceWidth = Screen.width; // ��� �ʺ� ����
    //    int deviceHeight = Screen.height; // ��� ���� ����

    //    Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

    //    if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
    //    {
    //        float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
    //        Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
    //    }
    //    else // ������ �ػ� �� �� ū ���
    //    {
    //        float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
    //        Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
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
