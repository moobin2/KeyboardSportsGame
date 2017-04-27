using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : Controller_Base
{
    public float inputTime = 0.5f;
    public float moveSpeed = 2.0f;

    private int _nAttackCount = 0;
    private float _fElapseTime = 0.3f;
	private Dictionary<char, Vector3> _dicKeyPosition;

    [SerializeField]
    private float _fAttackTime = 0.0f;
    private bool _bIsMoving = false;
    [SerializeField]
    private bool _bIsAttack = false;

    // Use this for initialization
    void Awake()
    {
        // 해금된 
        // 끼고있고
        base.Awake();

        //Manager_Effect.Instance.AddEffect("DestPosition", "FX_DestPosition", 10);

        DontDestroyOnLoad(this);
        gameObject.name = "[Player]Charater";
    }

    public void Init()
    {
        this.gameObject.SetActive(true);
        base.Init();
		_dicKeyPosition = new Dictionary<char, Vector3>();
		Transform[] keyTrans = GameObject.Find("Keyboard_Button").GetComponentsInChildren<Transform>();

		for (int i = 1; i < keyTrans.Length; i++)
		{
			_dicKeyPosition.Add(keyTrans[i].name[0].ToString().ToLower()[0], keyTrans[i].position);
		}

        currentBaseMotion = BASESTATE.Flying;
        base.SetMotionState(MOTIONSTATE.Idle);

        StartCoroutine("WaitForAttackCount");
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        KeyBoardInput();
    }

    void MoveUpdate()
    {
        if (_bIsMoving == false) return;

        //만약 움직이는 모션이 아니라면 움직이는 모션으로 바꿔준다.
        if(_fsmAnim.CurrentMotionState != MOTIONSTATE.Run)
        {
            base.SetMotionState(MOTIONSTATE.Run);
        }
    }

    void MoveComplete()
    {
        Debug.Log("이동완료");
        //_fsmAnim.SetState(UnitState.Idle);
        base.SetMotionState(MOTIONSTATE.Idle);
        iTween.Stop(gameObject);
        _bIsMoving = false;
    }

    void SetDestPosition(char KeyButtonName)
    {
        _bIsMoving = true;

        // 가야될 위치벡터
		Vector3 destPostion = _dicKeyPosition[KeyButtonName];
        destPostion.y = 0;
        //Manager_Effect.Instance.PlayEffect("DestPosition", destPostion);

        // 가야될 방향벡터 및 각도
        Vector3 nextDirection = (destPostion - transform.position).normalized;
        float dot = Vector3.Dot(nextDirection, Vector3.forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // 외적을 이용해 -180~180의 각도로 계산
        Vector3 temp = Vector3.Cross(Vector3.forward, nextDirection).normalized;
        angle = (temp.y > 0) ? angle : -angle;

        // 속도 계산
        float moveTime = (destPostion - transform.position).magnitude / moveSpeed;

        // iTween을 이용해 이동
        iTween.MoveTo(gameObject, iTween.Hash("position", destPostion, "time", moveTime, "easeType", "Linear", "oncomplete", "MoveComplete"));
        iTween.RotateTo(gameObject, new Vector3(0, angle, 0), inputTime - 0.1f);
    }

    void KeyBoardInput()
    {
        if (Input.inputString != "")
        {
            Debug.Log(Input.inputString);
            if(Input.inputString[0] == ' ')
            {
                SetAttack();
            }
            else
            {
			    SetDestPosition(Input.inputString[0]);
            }
		}
	}

    void SetAttack()
    {
        if(_fsmAnim.CurrentMotionState == MOTIONSTATE.Run || _fsmAnim.CurrentMotionState == MOTIONSTATE.Idle)
        {
            // idle 또는 run 상태라면 iTween을 멈춰 제자리에 멈추게 한다.
            _bIsMoving = false;
            _bIsAttack = true;
            _fAttackTime = 0.0f;
            iTween.Stop(gameObject);
            // 공격모션을 취하게 한다.
            switch (_nAttackCount)
            {
                case 0:
                    base.SetMotionState(MOTIONSTATE.Attack1);
                    break;
                case 1:
                    base.SetMotionState(MOTIONSTATE.Attack2);
                    break;
                case 2:
                    base.SetMotionState(MOTIONSTATE.Attack3);
                    break;
                case 3:
                    base.SetMotionState(MOTIONSTATE.JumpAttack);
                    break;
            }
            _nAttackCount++;
            if (_nAttackCount >= 4)
            {
                _nAttackCount = 0;
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator WaitForAttackCount()
    {
        while(true)
        {
            if(_bIsAttack)
            {
                _fAttackTime += Time.deltaTime;
                if(_fAttackTime > 1.0f + _fElapseTime)
                {
                    _fAttackTime = 0.0f;
                    _nAttackCount = 0;
                    _bIsAttack = false;
                }
            }
            yield return null;
        }
    }
}
