using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 매니저 추상클래스
public abstract class ManagerTemplate<T> : MonoBehaviour where T : ManagerTemplate<T>  
{
    public  static bool IsInitialized { private set; get; }       // 매니저 생성 유무 확인 변수

    private static T instance = null;
    public  static T Instance
    {
        get
        {
            if (IsInitialized == false)
            {
                Debug.LogError("생성아직 안됨.");
                return null;
            }

            return instance;
        }
    }

    public static bool Create()
    {
        if (instance != null)
        {
            Debug.LogError("이미있음 확인바람");
            return false;
        }
        else
        {
            instance = GameObject.FindObjectOfType(typeof(T)) as T;
            if (instance != null)
            {
                Debug.LogError("이미있음 확인바람");
                return false;
            }

            instance = new GameObject("[Manager]" + typeof(T).ToString(), typeof(T)).GetComponent<T>();
            if (instance == null)
            {
                Debug.LogError("매니저 생성 실패 : " + typeof(T).ToString());
                return false;
            }

            IsInitialized = true;
            instance.Init();
            DontDestroyOnLoad(instance.gameObject);
        }

        return true;
    }

    protected virtual void Init() { }

    protected virtual void OnDestroy()
    {
        IsInitialized = false;
        instance = null;
    }

    void OnApplicationQuit()
    {
        IsInitialized = false;
        instance = null;
    }
}
