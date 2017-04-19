using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Time : MonoBehaviour
{
    private UILabel _label;
    private int time = 0;

	// Use this for initialization
	void Start ()
    {
        _label = GetComponent<UILabel>();

        StartCoroutine("UpSecond");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator UpSecond()
    {
        yield return new WaitForSeconds(1.0f);
        time++;
        _label.text = time.ToString();

        StartCoroutine("UpSecond");
    }
}
