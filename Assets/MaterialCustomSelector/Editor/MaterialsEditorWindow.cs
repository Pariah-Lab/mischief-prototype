using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaterialsEditorWindow : EditorWindow
{
    public MaterialsList matList;

    public int submeshIndex;
    public int sharedMatsCount;
    GameObject currentSelected;
    public static void OpenMaterialsEditorWindow ()
    {
        GetWindow<MaterialsEditorWindow> ();
    }
    private void OnGUI ()
    {

        if (Selection.gameObjects.Length == 1)
        {
            if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MeshRenderer> () != null)
            {
                if (currentSelected != Selection.activeGameObject)
                {
                    submeshIndex = 0;
                    currentSelected = Selection.activeGameObject;
                }

                MeshRenderer renderer = Selection.activeGameObject.GetComponent<MeshRenderer> ();
                sharedMatsCount = renderer.sharedMaterials.Length;
                if (renderer.sharedMaterials.Length > 1)
                {
                    string btnName = $"materials: {Selection.activeGameObject.GetComponent<MeshRenderer>().sharedMaterials.Length} | edditing: {submeshIndex}";

                    if (GUILayout.Button (btnName))
                    {
                        submeshIndex++;
                        if (submeshIndex > Selection.activeGameObject.GetComponent<MeshRenderer> ().sharedMaterials.Length - 1)
                        {
                            submeshIndex = 0;
                        }
                    }
                }
            }

            foreach (var item in matList.allMaterials)
            {
                GUI.backgroundColor = item.color;
                if (GUILayout.Button (item.name))
                {
                    if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<MeshRenderer> () != null)
                    {

                        // if (item.HasProperty ("_Color"))
                        // {
                        //     GUI.backgroundColor = item.color;
                        // }
                        if (item.mainTexture != null)
                        {
                            GUI.DrawTexture (GUILayoutUtility.GetLastRect (), item.mainTexture);
                        }

                        MeshRenderer mshRndr = Selection.activeGameObject.GetComponent<MeshRenderer> ();
                        if (sharedMatsCount > 1)
                        {
                            Material[] tmp = mshRndr.sharedMaterials;
                            tmp[submeshIndex] = item;
                            mshRndr.sharedMaterials = tmp;
                        }
                        else
                        {
                            mshRndr.sharedMaterial = item;
                        }

                    }
                    else
                    {
                        Debug.Log ("Select a gameobject with Mesh Renderer");
                    }
                }
            }

        }
        else
        {
            foreach (var item in matList.allMaterials)
            {
                GUI.backgroundColor = item.color;
                if (GUILayout.Button (item.name))
                {
                    for (int i = 0; i < Selection.gameObjects.Length; i++)
                    {
                        if (Selection.gameObjects[i] != null && Selection.gameObjects[i].GetComponent<MeshRenderer> () != null)
                        {
                            if (item.mainTexture != null)
                            {
                                GUI.DrawTexture (GUILayoutUtility.GetLastRect (), item.mainTexture);
                            }

                            MeshRenderer mshRndr = Selection.gameObjects[i].GetComponent<MeshRenderer> ();
                            if (sharedMatsCount > 1)
                            {
                                Material[] tmp = mshRndr.sharedMaterials;
                                tmp[submeshIndex] = item;
                                mshRndr.sharedMaterials = tmp;
                            }
                            else
                            {
                                mshRndr.sharedMaterial = item;
                            }

                        }
                        else
                        {
                            Debug.Log ("Select a gameobject with Mesh Renderer");
                        }
                    }
                }
            }
        }
    }
    private void NextSubmesh ()
    {
        submeshIndex++;
    }
}