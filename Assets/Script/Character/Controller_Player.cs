using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSM_Player))]
public class Controller_Player : MonoBehaviour
{
    public float inputTime = 0.5f;
    public float moveSpeed = 2.0f;

    private int _nAttackCount = 0;
    private FSM_Player _fsmAnim;
    private float _fElapseTime = 0.5f;
    private float _fDestTime;
    private Vector3 _vDestPosition;
    private Vector3 _vDestRotate = Vector3.zero;
    private Vector3 _vCurrentDirection = Vector3.forward;
    private GameObject _keyboard;
    private bool _bIsMoving = false;

    // Use this for initialization
    void Start()
    {
        _fsmAnim = GetComponent<FSM_Player>();
        _keyboard = GameObject.Find("Keyboard_Button");
        _vDestPosition = gameObject.transform.localPosition;

        _fsmAnim.SetState(UnitState.Idle);
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
        if (_fsmAnim.currentState != UnitState.Run)
        {
            _fsmAnim.SetState(UnitState.Run);
        }
    }

    void MoveComplete()
    {
        Debug.Log("이동완료");
        _fsmAnim.SetState(UnitState.Idle);
        iTween.Stop(gameObject);
        _bIsMoving = false;
    }

    void SetDestPosition(string KeyButtonName)
    {
        _bIsMoving = true;

        // 가야될 위치벡터
        string ButtonObjectName = KeyButtonName + "_button";
        _vDestPosition = _keyboard.transform.FindChild(ButtonObjectName).transform.position;
        _vDestPosition.y = 0;
        //Manager_Effect.Instance.PlayEffect("5_FX_DestPosition", _vDestPosition);

        // 가야될 방향벡터 및 각도
        Vector3 nextDirection = (_vDestPosition - transform.position).normalized;
        float dot = Vector3.Dot(nextDirection, _vCurrentDirection);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // 외적을 이용해 -180~180의 각도로 계산
        Vector3 temp = Vector3.Cross(_vCurrentDirection, nextDirection).normalized;
        angle = (temp.y > 0) ? angle : -angle;

        // 속도 계산
        _fDestTime = (_vDestPosition - transform.position).magnitude / moveSpeed;

        _vDestRotate.y += angle;
        _vCurrentDirection = nextDirection;

        iTween.MoveTo(gameObject, iTween.Hash("position", _vDestPosition, "time", _fDestTime, "oncomplete", "MoveComplete"));
        iTween.RotateTo(gameObject, _vDestRotate, inputTime - 0.1f);
    }

    void KeyBoardInput()
    {
        if (Input.anyKey)
        {
            switch (Input.inputString)
            {
                // 키보드 상단 줄
                case "Q":
                case "q":
                    SetDestPosition("Q");
                    Debug.Log("Q button");
                    break;
                case "W":
                case "w":
                    SetDestPosition("W");
                    Debug.Log("W button");
                    break;
                case "E":
                case "e":
                    SetDestPosition("E");
                    Debug.Log("E button");
                    break;
                case "R":
                case "r":
                    SetDestPosition("R");
                    Debug.Log("R button");
                    break;
                case "T":
                case "t":
                    SetDestPosition("T");
                    Debug.Log("T button");
                    break;
                case "Y":
                case "y":
                    SetDestPosition("Y");
                    Debug.Log("Y button");
                    break;
                case "U":
                case "u":
                    SetDestPosition("U");
                    Debug.Log("U button");
                    break;
                case "I":
                case "i":
                    SetDestPosition("I");
                    Debug.Log("I button");
                    break;
                case "O":
                case "o":
                    SetDestPosition("O");
                    Debug.Log("O button");
                    break;
                case "P":
                case "p":
                    SetDestPosition("P");
                    Debug.Log("P button");
                    break;
                case "[":
                    SetDestPosition("[");
                    Debug.Log("[ button");
                    break;
                case "]":
                    SetDestPosition("]");
                    Debug.Log("] button");
                    break;
                //키보드 중간줄
                case "A":
                case "a":
                    SetDestPosition("A");
                    Debug.Log("A button");
                    break;
                case "S":
                case "s":
                    SetDestPosition("S");
                    Debug.Log("S button");
                    break;
                case "D":
                case "d":
                    SetDestPosition("D");
                    Debug.Log("D button");
                    break;
                case "F":
                case "f":
                    SetDestPosition("F");
                    Debug.Log("F button");
                    break;
                case "G":
                case "g":
                    SetDestPosition("G");
                    Debug.Log("G button");
                    break;
                case "H":
                case "h":
                    SetDestPosition("H");
                    Debug.Log("H button");
                    break;
                case "J":
                case "j":
                    SetDestPosition("J");
                    Debug.Log("J button");
                    break;
                case "K":
                case "k":
                    SetDestPosition("K");
                    Debug.Log("K button");
                    break;
                case "L":
                case "l":
                    SetDestPosition("L");
                    Debug.Log("L button");
                    break;
                case ";":
                    SetDestPosition(";");
                    Debug.Log("; button");
                    break;
                case "'":
                    SetDestPosition("'");
                    Debug.Log("' button");
                    break;
                //키보드 하단줄
                case "Z":
                case "z":
                    SetDestPosition("Z");
                    Debug.Log("Z button");
                    break;
                case "X":
                case "x":
                    SetDestPosition("X");
                    Debug.Log("X button");
                    break;
                case "C":
                case "c":
                    SetDestPosition("C");
                    Debug.Log("C button");
                    break;
                case "V":
                case "v":
                    SetDestPosition("V");
                    Debug.Log("V button");
                    break;
                case "B":
                case "b":
                    SetDestPosition("B");
                    Debug.Log("b button");
                    break;
                case "N":
                case "n":
                    SetDestPosition("N");
                    Debug.Log("N button");
                    break;
                case "M":
                case "m":
                    SetDestPosition("M");
                    Debug.Log("M button");
                    break;
                case ",":
                    SetDestPosition(",");
                    Debug.Log(", button");
                    break;
                case ".":
                    SetDestPosition(".");
                    Debug.Log(". button");
                    break;
                case "/":
                    SetDestPosition("/");
                    Debug.Log("/ button");
                    break;
                case " ":
                    Debug.Log("Space Button");
                    switch (_nAttackCount)
                    {
                        case 0:
                            _fsmAnim.SetState(UnitState.Attack2);
                            break;
                        case 1:
                            _fsmAnim.SetState(UnitState.Attack3);
                            break;
                        case 2:
                            _fsmAnim.SetState(UnitState.Attack1);
                            break;
                        case 3:
                            _fsmAnim.SetState(UnitState.JumpAttack);
                            break;
                    }
                    _nAttackCount++;
                    if (_nAttackCount > 4)
                    {
                        _nAttackCount = 0;
                    }
                    //FSMAnim.AttackMotion();
                    break;
                    //default:
                    //    Debug.Log(Input.inputString);
                    //    break;
            }

        }
    }
}
