using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectThingsByName : EditorWindow
{
    static SelectThingsByName window;
    string textField;
   // [MenuItem("Tools/Select stuff by name")]
    public static void SelectByName()
    {
        window = ScriptableObject.CreateInstance<SelectThingsByName>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    void OnGUI()
    {
        
        EditorGUILayout.LabelField("How does your object name starts, sir?", EditorStyles.wordWrappedLabel);
        EditorGUILayout.Space(30);
        EditorGUI.TextField(new Rect(new Vector2(10, 30),new Vector2(0,0)),"Name your need, sir!", textField, EditorStyles.wordWrappedLabel);
        EditorGUILayout.TextArea(textField);
        

        GUILayout.Space(60);
        if (GUILayout.Button("Agree!"))
        {
            
            GameObject[] objs = Selection.gameObjects;
            List<GameObject> childrens = new List<GameObject>();
            foreach (GameObject obj in objs)
            {
                if (obj.gameObject.name.StartsWith(textField))
                {
                    childrens.Add(obj.transform.gameObject);
                }
            }
            Selection.objects = childrens.ToArray(); this.Close();
        }
    }
}
