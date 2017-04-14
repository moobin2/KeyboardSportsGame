using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Arrow : MonoBehaviour
{
    public bool IsFire;
    private float _arrowSpeed = 1.0f;

    // Use this for initialization
    void Start()
    {
        _arrowSpeed = 1.0f;
        IsFire = false;
    }

    public void FireArrow(Vector3 firePos, Vector3 targetPos)
    {
        IsFire = true;
        this.gameObject.SetActive(true);
        this.transform.localPosition = firePos;

        Vector3 destArrowDir = targetPos - firePos;

        float time = destArrowDir.magnitude / _arrowSpeed;

        // Y축 회전각 구하기
        Vector3 destArrowDirXZ = destArrowDir;
        destArrowDirXZ.y = 0;
        destArrowDirXZ = destArrowDirXZ.normalized;
        float angleY = Mathf.Acos(Vector3.Dot(destArrowDirXZ, Vector3.forward)) * Mathf.Rad2Deg;

        // 외적을 이용해 -180~180의 각도로 계산
        Vector3 temp = Vector3.Cross(Vector3.forward, destArrowDirXZ).normalized;
        angleY = (temp.y > 0) ? angleY : -angleY;

        // X축 회전각 구하기
        destArrowDir = destArrowDir.normalized;
        float dotX = Vector3.Dot(destArrowDirXZ, destArrowDir);
        float angleX = Mathf.Acos(dotX) * Mathf.Rad2Deg;

        // itween을 이용해 이동, 회전 이동이 끝났다면 ArrowMoveComplete()함수 실행
        iTween.MoveTo(gameObject, iTween.Hash("position", targetPos, "time", time, "easeType", "Linear", "oncomplete", "ArrowMoveComplete"));
        iTween.RotateTo(gameObject, new Vector3(angleX, angleY, 0), 0.3f);
    }

    void ArrowMoveComplete()
    {
        IsFire = false;
        this.gameObject.SetActive(false);

        // 여기서 이펙트 on
    }
}
