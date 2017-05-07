using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Time : UIPanel_Template<UIPanel_Time>
{
    private UILabel _label;

	// Use this for initialization
	void Start ()
    {
        _label = GetComponent<UILabel>();
	}

    public void SetTime(int time)
    {
        int minute = time / 60;
        int second = time % 60;

        _label.text = minute.ToString() + " : " + second.ToString();
    }
}
