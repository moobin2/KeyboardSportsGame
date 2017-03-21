using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFadeInOut : MonoBehaviour
{
    private GUIStyle    m_BackgroundStyle = new GUIStyle();
    private Texture2D   m_FadeTexture;
    private Color       m_CurrentScreenOverlayColor = new Color(0, 0, 0, 0);
    private Color       m_TargetScreenOverlayColor = new Color(0, 0, 0, 0);
    private Color       m_DeltaColor = new Color(0, 0, 0, 0);
    private int         m_FadeGUIDepth = -1000;

    void Start ()
    {
        m_FadeTexture = new Texture2D(1, 1);
        m_BackgroundStyle.normal.background = m_FadeTexture;
        SetScreenOverlayColor(m_CurrentScreenOverlayColor);
    }

    private void OnGUI()
    {
        if (m_CurrentScreenOverlayColor != m_TargetScreenOverlayColor)      // 현재씬의 칼라와 바뀔씬의 컬러가 다르다면.
        {
            if (Mathf.Abs(m_CurrentScreenOverlayColor.a - m_TargetScreenOverlayColor.a) < Mathf.Abs(m_DeltaColor.a) * Time.deltaTime)
            {
                m_CurrentScreenOverlayColor = m_TargetScreenOverlayColor;
                SetScreenOverlayColor(m_CurrentScreenOverlayColor);
                m_DeltaColor = new Color(0, 0, 0, 0);
            }
            else
            {
                SetScreenOverlayColor(m_CurrentScreenOverlayColor + m_DeltaColor * Time.deltaTime);
            }
        }

        if (m_CurrentScreenOverlayColor.a > 0)
        {
            GUI.depth = m_FadeGUIDepth;
            GUI.Label(new Rect(-10, -10, Screen.width + 10, Screen.height + 10), m_FadeTexture, m_BackgroundStyle);
        }
        else
        {
            this.enabled = false;
        }
    }

    public void SetScreenOverlayColor(Color newScreenOverlayColor)
    {
        m_CurrentScreenOverlayColor = newScreenOverlayColor;
        m_FadeTexture.SetPixel(0, 0, m_CurrentScreenOverlayColor);
        m_FadeTexture.Apply();
    }


    public void StartFade(Color newScreenOverlayColor, float fadeDuration)
    {
        this.enabled = true;
        if (fadeDuration <= 0.0f)		// can't have a fade last -2455.05 seconds!
        {
            SetScreenOverlayColor(newScreenOverlayColor);
        }
        else					// initiate the fade: set the target-color and the delta-color
        {
            m_TargetScreenOverlayColor = newScreenOverlayColor;
            m_DeltaColor = (m_TargetScreenOverlayColor - m_CurrentScreenOverlayColor) / fadeDuration;
            //            Debug.Log("FadeIn : " + m_TargetScreenOverlayColor + " , " + m_DeltaColor + "  : " + fadeDuration);

        }
    }

    public void FadeIn(float fadeDuration)
    {
        FadeIn(fadeDuration, Color.black);
    }

    public void FadeOut(float fadeDuration)
    {
        FadeOut(fadeDuration, Color.black);
    }

    public void FadeIn(float fadeDuration, Color color)
    {
        m_TargetScreenOverlayColor = color;
        m_TargetScreenOverlayColor.a = 0;
        StartFade(m_TargetScreenOverlayColor, fadeDuration * (m_CurrentScreenOverlayColor.a));
    }

    public void FadeOut(float fadeDuration, Color color)
    {
        m_TargetScreenOverlayColor = color;
        m_TargetScreenOverlayColor.a = 1;

        StartFade(m_TargetScreenOverlayColor, fadeDuration * (m_TargetScreenOverlayColor.a - m_CurrentScreenOverlayColor.a));

    }
}
