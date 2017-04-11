using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Arrow : MonoBehaviour
{
    public bool IsFire;
    private float _arrowSpeed; 

	// Use this for initialization
	void Start ()
    {
        _arrowSpeed = 0.0f;
        IsFire = false;	
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void FireArrow(Vector3 firePos, Vector3 targetPos)
    {
        // 
        IsFire = true;
        this.gameObject.SetActive(true);
        this.transform.localPosition = firePos;

        float arriwTime = (targetPos - firePos).magnitude / _arrowSpeed;

        Vector3 destArrowDir = targetPos - firePos;
        destArrowDir.y = 0;
        float dot = Vector3.Dot(targetPos - firePos, destArrowDir);
        float angle = dot * Mathf.Rad2Deg;

        iTween.MoveTo(gameObject, iTween.Hash("position" , targetPos, "time", arriwTime, "easeType", "Linear", "oncomplete", "ArrowMoveComplete"));
        iTween.RotateTo(gameObject, new Vector3(angle, 0, 0), 0.3f);
    }

    void ArrowMoveComplete()
    {
        IsFire = false;
        this.gameObject.SetActive(false);

        // 여기서 이펙트 on
    }
}
