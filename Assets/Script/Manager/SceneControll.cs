using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneControll : MonoBehaviour
{
    // GameScene 매니저에서 씬 로드 후 불려질 함수
    // 로드된 씬의 초기화를 담당한다.    
    public abstract void InitScene(params object[] args);

    // 씬 전환 하기 전에 이 씬에서 릴리즈 할 함수
    // 씬 전환 전에 이 씬을 릴리즈 한다.
    public abstract void ReleaseScene(params object[] args);
}
