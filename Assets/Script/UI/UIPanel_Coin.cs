using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Coin : UIPanel_Template<UIPanel_Coin>
{
    public UILabel coinTextLabel;

	// Use this for initialization
	void Start ()
    {
        coinTextLabel = GetComponent<UILabel>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetCoin(int coin)
    {
        coinTextLabel.text = coin.ToString();
    }
}
