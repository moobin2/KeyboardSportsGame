using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EGameScene
{
    NONE, TITLE, MAIN,
}

public class Manager_GameScene : Manager_Template<Manager_GameScene>
{

    private EGameScene currentScene = EGameScene.NONE;
    public EGameScene CurrentScene { get { return currentScene; } }

    [Header("fade In out")]
    private CameraFadeInOut fadeInOutCtrl = null;
    public float FadeOutTime = 0.5f;
    public float FadeInTime = 0.5f;

    public SceneControll CurrentSceneCtrl { get; private set; }

    protected override void Init()
    {
        if (fadeInOutCtrl == null)
        {
            fadeInOutCtrl = GetComponent<CameraFadeInOut>();
            if (fadeInOutCtrl == null)
            {
                fadeInOutCtrl = this.gameObject.AddComponent<CameraFadeInOut>();
            }
        }

        Manager_UI.Instance.InitSceneUI(EGameScene.TITLE);
        Debug.Log("<color=lightblue> Manager Initialize =>  </color>" + this.name.ToString());
    }

    public void ChangeScene(EGameScene scene)
    {
        this.ChangeScene(scene, null, null);
    }

    public void ChangeScene(EGameScene scene, Hashtable hash, System.Action onComplete)
    {
        switch (scene)
        {
            case EGameScene.TITLE:
                {
                    this.loadScene("", onComplete);
                }
                break;
            case EGameScene.MAIN:
                {
                    this.loadScene("MainScene", onComplete);
                }
                break;
        }
    }

    private void loadScene(string sceneName, System.Action onComplete)
    {
        StartCoroutine(coLoadScene(sceneName, onComplete));
    }

    private IEnumerator coLoadScene(string sceneName, System.Action onComplete)
    {
        this.fadeInOutCtrl.FadeOut(this.FadeOutTime);
        yield return new WaitForSeconds(this.FadeOutTime);

        if (CurrentSceneCtrl != null)
        {
            CurrentSceneCtrl.ReleaseScene();
        }

        Manager_UI.Instance.HideAllPanel();

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        yield return async;

        if (onComplete != null)
        {
            onComplete.Invoke();
        }

        Manager_UI.Instance.InitSceneUI(currentScene);
        // 로드가 끝난후 페이드 인 들어가게 바꾼다.
        this.fadeInOutCtrl.FadeIn(this.FadeInTime);
    }
}
