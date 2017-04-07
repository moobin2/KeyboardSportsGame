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

        LoadEffectResources();
    }

    void LoadEffectResources()
    {
        GameObject[] LoadEffects = Resources.LoadAll<GameObject>(effectContainerPath);

        for(int i = 0; i < LoadEffects.Length; ++i)
        {
            AddEffect(LoadEffects[i], 10);
        }
    }

    void AddEffect(GameObject effect, int effectSize)
    {
        List<GameObject> _effectList = new List<GameObject>();

        effect.transform.localPosition = Vector3.zero;
        effect.transform.localScale = Vector3.one;

        for(int i = 0; i < effectSize; ++i)
        {
            _effectList.Add(effect);
        }

        _effectsDic.Add(effect.transform.ToString(), _effectList);
    }

    public void PlayEffect(string effectName, Vector3 effectPostion)
    {
        for(int i = 0; i < 10; ++i)
        {
            ParticleSystem particle = _effectsDic[effectName][i].GetComponent<ParticleSystem>();

            if (particle.isPlaying == true)
                continue;
            else
            {
                _effectsDic[effectName][i].transform.localPosition = effectPostion;
                particle.Play();
                break;
            }
        }
    }
}
