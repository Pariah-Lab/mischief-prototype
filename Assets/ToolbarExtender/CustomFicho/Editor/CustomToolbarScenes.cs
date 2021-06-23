#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

using UnityToolbarExtender;

[InitializeOnLoad]
public static class CustomToolbarScenes 
{

        static string[] scenes;

        static string[] scenesFullPath;

        static int selectedIndex;

		static CustomToolbarScenes()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);

            OnEnable();
		}

        static void OnEnable()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings + 1;
            scenes = new string[sceneCount];

            scenesFullPath = new string[sceneCount];

            scenes[0] = SceneManager.GetActiveScene().name;

            scenesFullPath[0] = SceneManager.GetActiveScene().path;

            for (int i = 1; i < sceneCount; i++)
            {

                scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i-1));
  
                scenesFullPath[i] = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i-1);
            }

            selectedIndex = 0;
            

        }

		static void OnToolbarGUI()
		{
			GUILayout.FlexibleSpace();

    

            int tempIndex = EditorGUILayout.Popup(selectedIndex,scenes);
          
            if(tempIndex!=selectedIndex)
            {
                selectedIndex = tempIndex;

                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scenesFullPath[selectedIndex]);
             
            }    


		} 



}


#endif