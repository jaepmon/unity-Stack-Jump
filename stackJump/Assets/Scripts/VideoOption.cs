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
