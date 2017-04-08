using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager_Effect : Manager_Template<Manager_Effect>
{
    public const string effectContainerPath = "Effect/";

    private Dictionary<string, List<GameObject>>    _effectsDic;
    public Dictionary<string, List<GameObject>>     EffectDic
    {
        get { return _effectsDic; }
    }

    protected override void Init()
    {
        base.Init();

        _effectsDic = new Dictionary<string, List<GameObject>>();
    }

    public void AddEffect(string effectName, string effectFileName, int effectSize)
    {
        List<GameObject> _effectList = new List<GameObject>();

        GameObject effectRoot = new GameObject();
        effectRoot.transform.localPosition = Vector3.zero;
        effectRoot.transform.localScale = Vector3.one;
        effectRoot.transform.parent = this.transform;
        effectRoot.name = effectName + "Root";

        GameObject effect = Resources.Load(effectContainerPath + effectFileName) as GameObject;

        for (int i = 0; i < effectSize; ++i)
        {
            GameObject addEffect = Instantiate(effect) as GameObject;
            addEffect.transform.localPosition = Vector3.zero;
            addEffect.transform.localScale = Vector3.one;
            addEffect.transform.parent = effectRoot.transform;
            addEffect.name = "FX_" + effectName + i;
            _effectList.Add(addEffect);
        }

        _effectsDic.Add(effectName, _effectList);
    }

    public void PlayEffect(string effectName, Vector3 effectPostion)
    {
        int effectSize = _effectsDic[effectName].Count;

        for(int i = 0; i < effectSize; ++i)
        {
            ParticleSystem particle = _effectsDic[effectName][i].GetComponent<ParticleSystem>();

            if (particle.isPlaying == true)
            {
                Debug.Log(i + "번째 이펙트 패스");
                continue;
            }
            else
            {
                Debug.Log(i + "번째 이펙트 출력");
                _effectsDic[effectName][i].transform.localPosition = effectPostion;
                particle.Play();
                break;
            }
        }
    }
}
