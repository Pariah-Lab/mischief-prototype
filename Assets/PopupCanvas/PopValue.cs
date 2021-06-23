using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DataSystem;
public class PopValue : MonoBehaviour
{
    [SerializeField] GameObject popupValue;
    [SerializeField] RectTransform myRect;
    public GameEvent OnPopValueString;
    int childCounter;

    Camera cam_main;
    private void Start()
    {
        //OnPopValueString.OnRaiseString += PopFeedback;
        cam_main = Camera.main;
    }

    public void PopFeedback(string value)
    {
        GameObject tmpValue = Instantiate(popupValue, myRect.position, Quaternion.identity, myRect);
        //transform.GetChild(childCounter);
        tmpValue.transform.parent = myRect;
        myRect.localPosition = Vector3.zero;
        tmpValue.GetComponentInChildren<TMP_Text>().text = value;
    }
    public void PopHere(Vector3 worldSpacePosition, int value)
    {
        transform.GetChild(childCounter).gameObject.SetActive(true);
        Vector3 worldToCanvasPos = cam_main.WorldToScreenPoint(worldSpacePosition);
        //GameObject tmpValue = Instantiate(popupValue, worldToCanvasPos, Quaternion.identity, myRect);
        transform.GetChild(childCounter).GetComponent<RectTransform>().position = worldToCanvasPos;
        transform.GetChild(childCounter).GetComponent<PopupValueDisplayHandler>().SetPopup(value);
        //tmpValue.transform.parent = myRect;
        transform.GetChild(childCounter).GetComponentInChildren<TMP_Text>().text = value.ToString();
        childCounter++;
        if (childCounter > transform.childCount - 1)
        {
            childCounter = 0;
        }
    }

    private void OnDestroy()
    {
        //OnPopValueString.OnRaiseString -= PopFeedback;
    }

}
