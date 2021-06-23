using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaterialSelectionEditor : Editor
{
    [MenuItem ("MatAssist/MatAssist %w")]
    static void AssistWithSelectedMaterial ()
    {
        foreach (Object o in Selection.objects)
        {
            Debug.Log ("selected: " + o.name);
            if (o.GetType () == typeof (Material))
            {
                Material selectedMat = o as Material;
                Color baseColor = selectedMat.GetColor ("_Color");
                Color HighlightColor = selectedMat.GetColor ("_HColor");
                Color ShadowColor = selectedMat.GetColor ("_SColor");
                Color SpecularColor = selectedMat.GetColor ("_SpecColor");
                Color RimColor = selectedMat.GetColor ("_RimColor");

                selectedMat.SetColor ("_HColor", ConvertColor (baseColor, false, 0, false, 0.5f));
                selectedMat.SetColor ("_SColor", ConvertColor (baseColor, false, 0, true, 0.5f));
                selectedMat.SetColor ("_SpecularColor", ConvertColor (baseColor, false, 0, false, 0.5f));
                selectedMat.SetColor ("_RimColor", ConvertColor (baseColor, false, 0, false, 0f));
            }
        }
    }
    static Color ConvertColor (Color bColor, bool reduceSaturation, float amountSaturation, bool reduceValueIncreaseValue, float amountValue)
    {
        float h;
        float s;
        float v;
        Color.RGBToHSV (bColor, out h, out s, out v);
        Color endColor;
        if (reduceSaturation)
        {

            s -= s * amountSaturation;
        }
        else
        {
            s += s * amountSaturation;
        }
        if (reduceValueIncreaseValue)
        {
            v -= v * amountValue;
        }
        else
        {
            v += v * amountValue;
        }
        endColor = Color.HSVToRGB (h, s, v);
        return endColor;
    }
}