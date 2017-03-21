using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(UIPanel))]
public class UIPanel_Base : MonoBehaviour
{
    private StringBuilder _strBuilder = new StringBuilder("");

    protected virtual void init() { }

    public void showPanel()
    {
        this.gameObject.SetActive(true);
    }

    public void hidePanel()
    {
        this.gameObject.SetActive(false);
    }
}

