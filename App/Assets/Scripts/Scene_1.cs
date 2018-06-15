using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_1
    : MonoBehaviour
{
    DynamicObject dynamicObject = null;


    void Start ()
    {
    
    }

    void Update ()
    {

    }


    private void OnGUI()
    {
        //
        {
            GUIStyle buttonStyle = GUI.skin.button;//("button");
            if (buttonStyle != null)
            {
                buttonStyle.fontSize = 24;
            }
        }

        //
        {
            GUIStyle labelStyle = GUI.skin.label;
            if (labelStyle != null)
            {
                labelStyle.fontSize = 24;
            }
        }

        //
        Rect screenRect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
        GUILayout.BeginArea(screenRect);
        {
            GUILayout.BeginVertical();
            {
                // インスタンス状況
                string liveLabel = dynamicObject ? "<color=red>Alive</color>" : "<color=black>None</color>";
                GUILayout.Label("DynamicObject=" + liveLabel);

                // ボタンの横幅
                GUILayoutOption buttonMaxWidth = GUILayout.MaxWidth(512.0f);

                // 作成ボタン
                if (GUILayout.Button("Create", buttonMaxWidth))
                {
                    if (!dynamicObject)
                    {
                        GameObject gameObject = new GameObject("DynamicObject");
                        dynamicObject = gameObject.AddComponent<DynamicObject>();
                        dynamicObject.CreateCube();
                    }
                }


                // Sceneセクション
                GUILayout.Label("<color=green>Scene側から</color>");

                // 破棄ボタン
                if (GUILayout.Button("Destroy", buttonMaxWidth))
                {
                    GameObject.Destroy(dynamicObject.gameObject);
                }
                // 即破棄ボタン
                if (GUILayout.Button("DestroyImmediate", buttonMaxWidth))
                {
                    GameObject.DestroyImmediate(dynamicObject.gameObject);
                }


                // DynamicObjectセクション
                GUILayout.Label("<color=navy>DynamicObject側から</color>");

                // 破棄ボタン
                if (GUILayout.Button("Destroy", buttonMaxWidth))
                {
                    if (dynamicObject)
                    {
                        dynamicObject.DestroyMyself();
                    }
                }

                // 即破棄ボタン
                if (GUILayout.Button("DestroyImmediate", buttonMaxWidth))
                {
                    if (dynamicObject)
                    {
                        dynamicObject.DestroyImmediateMyself();
                    }
                }

                // 時間差破棄ボタン
                if (GUILayout.Button("DestroyDelay(1.0sec)", buttonMaxWidth))
                {
                    if (dynamicObject)
                    {
                        dynamicObject.DestroyMyselfDelay(1.0f);
                    }
                }

                // Cubeだけ破棄ボタン
                if (GUILayout.Button("Destroy Cube", buttonMaxWidth))
                {
                    if (dynamicObject)
                    {
                        dynamicObject.DestroyCube();
                    }
                }
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndArea();
    }
}
