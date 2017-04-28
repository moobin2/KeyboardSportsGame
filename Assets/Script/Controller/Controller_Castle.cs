using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Controller_Castle : MonoBehaviour
{
    public GameObject objectContainer;

    private Animator    _anim;
    private bool        _bIsOpen;
    private Pool_Controller _archerPool;

    float time = 0.0f;
    bool _isArcher = false;

    // Use this for initialization
    void Start ()
    {
        _bIsOpen = false;
        _anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;

        if(_isArcher == false)
        {
            if(time > 3)
            {
                _isArcher = true;
                SetArcher();
            }
        }

    }

    public void SetArcher()
    {
        _isArcher = true;

        //_archerPool = GetComponent<Pool_Controller>();
        GameObject archer = objectContainer.GetComponent<Pool_Controller>().GetObjcet("Archer");
        //Vector3 archerPos = this.transform.position;
        //archerPos.y = 3;

        //archer.SetActive(true);
        //archer.transform.position = archerPos;
        //archer.GetComponent<Controller_Archer>().Init();
    }
}
