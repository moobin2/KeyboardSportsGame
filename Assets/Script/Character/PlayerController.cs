using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSMAnimation))]
public class PlayerController : MonoBehaviour {

    FSMAnimation    FSMAnim;
    float           InputTime = 0.2f;
    float           CurrentSpeed;
    float           MaxSpeed = 5.0f;
    Vector3         DestPosition;
    Vector3         MoveSpeedVec = Vector3.zero;
    GameObject      Keyboard;
    bool            IsMoving = false;
	
    // Use this for initialization
	void Start ()
    {
        FSMAnim = GetComponent<FSMAnimation>();
        Keyboard = GameObject.Find("Keyboard_Button");
        DestPosition = gameObject.transform.localPosition;

        FSMAnim.SetState(eUnitState.Idle);
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveUpdate();
        KeyBoardInput();
	}

    void MoveUpdate()
    {
        if (IsMoving == false) return;

        //transform.localPosition = Vector3.Lerp(transform.localPosition, DestPosition, MoveSpeed);

        transform.position = Vector3.SmoothDamp(transform.position, DestPosition, ref MoveSpeedVec, 0.5f, 2.0f );
        //MoveSpeed += 0.1f;

        //Debug.Log(MoveSpeed);
        //if(Vector3.Magnitude(new Vector3(transform.localPosition - DestPosition)))
        //{

        //}
    }

    void SetDestPosition(string KeyButtonName)
    {
        string ButtonObjectName = KeyButtonName + "_button";
        // "/" 버튼 누르면 아래 FindChild가 안됨 이유를 모르겠음. 오브젝트네임드  /_button 으로 찾는건데  
        DestPosition = Keyboard.transform.FindChild(ButtonObjectName).transform.position;
        DestPosition.y = 0;

        if (IsMoving == true)
        {
            CurrentSpeed = 2.0f;
        }
        else
        {
            CurrentSpeed = 0.0f;
            IsMoving = true;
        }
        FSMAnim.currentState = eUnitState.Run;
    }

    void KeyBoardInput()
    {
        if(Input.anyKey)
        {
            switch (Input.inputString)
            {
                // 키보드 상단 줄
                case "Q": case "q":
                    SetDestPosition("Q");
                    Debug.Log("Q button");
                    break;
                case "W": case "w":
                    SetDestPosition("W");
                    Debug.Log("W button");
                    break;
                case "E": case "e":
                    SetDestPosition("E");
                    Debug.Log("E button");
                    break;
                case "R": case "r":
                    SetDestPosition("R");
                    Debug.Log("R button");
                    break;
                case "T": case "t":
                    SetDestPosition("T");
                    Debug.Log("T button");
                    break;
                case "Y": case "y":
                    SetDestPosition("Y");
                    Debug.Log("Y button");
                    break;
                case "U": case "u":
                    SetDestPosition("U");
                    Debug.Log("U button");
                    break;
                case "I": case "i":
                    SetDestPosition("I");
                    Debug.Log("I button");
                    break;
                case "O": case "o":
                    SetDestPosition("O");
                    Debug.Log("O button");
                    break;
                case "P": case "p":
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
                case "A": case "a":
                    SetDestPosition("A");
                    Debug.Log("A button");
                    break;
                case "S": case "s":
                    SetDestPosition("S");
                    Debug.Log("S button");
                    break;
                case "D": case "d":
                    SetDestPosition("D");
                    Debug.Log("D button");
                    break;
                case "F": case "f":
                    SetDestPosition("F");
                    Debug.Log("F button");
                    break;
                case "G": case "g":
                    SetDestPosition("G");
                    Debug.Log("G button");
                    break;
                case "H": case "h":
                    SetDestPosition("H");
                    Debug.Log("H button");
                    break;
                case "J": case "j":
                    SetDestPosition("J");
                    Debug.Log("J button");
                    break;
                case "K": case "k":
                    SetDestPosition("K");
                    Debug.Log("K button");
                    break;
                case "L": case "l":
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
                case "Z": case "z":
                    SetDestPosition("Z");
                    Debug.Log("Z button");
                    break;
                case "X": case "x":
                    SetDestPosition("X");
                    Debug.Log("X button");
                    break;
                case "C": case "c":
                    SetDestPosition("C");
                    Debug.Log("C button");
                    break;
                case "V": case "v":
                    SetDestPosition("V");
                    Debug.Log("V button");
                    break;
                case "B": case "b":
                    SetDestPosition("B");
                    Debug.Log("b button");
                    break;
                case "N": case "n":
                    SetDestPosition("N");
                    Debug.Log("N button");
                    break;
                case "M": case "m":
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
                    FSMAnim.SetState(eUnitState.Attack);
                    //FSMAnim.AttackMotion();
                    break;
                //default:
                //    Debug.Log(Input.inputString);
                //    break;
            }

        }
    }
}
