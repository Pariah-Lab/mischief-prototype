using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using DataSystem;

[CustomPropertyDrawer(typeof(IntReferenceValue))]
[CanEditMultipleObjects]
public class IntReferenceEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // bool sendOnChangeEvents = property.FindPropertyRelative("SendOnChangeEvents").boolValue;
        EditorGUI.BeginProperty(position, label, property);
        bool useConstant = property.FindPropertyRelative("UseConstant").boolValue;
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var rect = new Rect(new Vector2(position.position.x - 10, position.y), Vector2.one * 20);
        if (EditorGUI.DropdownButton(rect,
        new GUIContent(GetTexture(useConstant)), FocusType.Keyboard, new GUIStyle()
        {
            fixedWidth = 50f,
            border = new RectOffset(1, 1, 1, 1)
        }))
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Constant"), useConstant, () => SetProperty(property, true));
            menu.AddItem(new GUIContent("Variable"), !useConstant, () => SetProperty(property, false));

            menu.ShowAsContext();
        }
        position.position += Vector2.right * 15;
        int value = property.FindPropertyRelative("ConstantValue").intValue;

        if (useConstant)
        {
            string newValue = EditorGUI.TextField(position, value.ToString());
            int.TryParse(newValue, out value);
            property.FindPropertyRelative("ConstantValue").intValue = value;
        }
        else
        {
            EditorGUI.ObjectField(position, property.FindPropertyRelative("Variable"), GUIContent.none);
        }

        EditorGUI.EndProperty();
    }
    public Texture GetTexture(bool messages)
    {
        Texture2D send = Resources.Load("SendingEvents") as Texture2D;
        Texture2D dontsend = Resources.Load("EmptyEvent") as Texture2D;

        if (!messages)
        {
            return send;
        }
        else
        {
            return dontsend;
        }
    }
    // private void SetPropertyEventSend(SerializedProperty property, bool value)
    // {
    //     var propRelative = property.FindPropertyRelative("SendOnChangeEvents");
    //     propRelative.boolValue = value;
    //     property.serializedObject.ApplyModifiedProperties();
    // }
    private void SetProperty(SerializedProperty property, bool value)
    {
        var propRelative = property.FindPropertyRelative("UseConstant");
        propRelative.boolValue = value;
        property.serializedObject.ApplyModifiedProperties();
    }
}
