using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.ProceduralImage;
using Lean.Touch;


public class SlideItemsHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform itemsHolder;
    public RectTransform myRect;
    bool pressed;
    Vector2 startPosition;
    float deltaX;
    float closest;
    public float currentClosest;
    public float currentTested;
    public float spacingg = 1500;
    PointerEventData ped;
    Vector2 lerpToThisPosition;
    ShopItemsHandler shopItems;
    public IntValue inShopSelectedWeapon;
    public float eventDataPositionX;
    public string slectedElement;
    public float[] pageXValues;
    public float sensitivity = 2f;
    public float yOffset;
    public float distanceTrasshold;
    public float distanceCounter;
    public float offset;
    private void OnEnable()
    {
        shopItems = GetComponentInChildren<ShopItemsHandler>();
        LeanTouch.OnFingerUpdate += DragStore;
        LeanTouch.OnFingerUp += OnFingerUp;
        LeanTouch.OnFingerDown += OnFingerDown;
        spacingg = 0;
        offset = Vector3.Distance(myRect.position, itemsHolder.GetChild(0).position);
        //PageXPositionsCounter();
    }
    private void DragStore(LeanFinger finger)
    {
        if (itemsHolder.childCount>1)
        {
            distanceCounter += Mathf.Abs(finger.ScaledDelta.x * sensitivity);
            pressed = true;
            if (distanceCounter > distanceTrasshold)
            {
                itemsHolder.localPosition += new Vector3(finger.ScaledDelta.x * sensitivity, yOffset, 0);  
            }
        }
    }
    private void PageXPositionsCounter()
    {
        pageXValues = new float[3];


        for (int i = 0; i < itemsHolder.childCount; i++)
        {
            pageXValues[i] = itemsHolder.GetChild(i).transform.position.x;
        }

    }
    private void OnFingerDown(LeanFinger finger)
    {
        startPosition = finger.ScreenPosition;

    }
    private void OnFingerUp(LeanFinger finger)
    {
        pressed = false;
        distanceCounter = 0;
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //startPosition = eventData.position;
        //pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    //void Update()
    //{
    //    //PageXPositionsCounter();
    //        if (!pressed)
    //        {
    //            itemsHolder.localPosition = Vector2.Lerp(itemsHolder.localPosition, new Vector3(lerpToThisPosition.x, yOffset), Time.deltaTime * 4f);
    //        }
    //        CalculateClosestPointToMiddle();
    //}

    void CalculateClosestPointToMiddle()
    {
        closest = 1000000f;
        int closestIndex = 0;
        if (itemsHolder.childCount > 1)
        {
            spacingg = Mathf.Abs(itemsHolder.GetChild(0).position.x - itemsHolder.GetChild(1).position.x);
            offset = Vector3.Distance(myRect.position, itemsHolder.GetChild(0).position);
        }
        for (int i = 0; i < itemsHolder.childCount; i++)
        {
            //currentTested = (Mathf.Abs(myRect.position.x)) - (Mathf.Abs(itemsHolder.GetChild(i).position.x));
            currentTested = Vector3.Distance(myRect.position, itemsHolder.GetChild(i).position);
            if (Mathf.Abs(currentTested) < Mathf.Abs(closest))
            {
                currentClosest = Mathf.Abs(currentTested);
                closest = currentClosest;
                closestIndex = i;
                Vector2 lerpTO = new Vector2(offset - (i * spacingg), 0);
                lerpToThisPosition = lerpTO;

            }
        }
        //for (int i = 0; i < itemsHolder.childCount; i++)
        //{
        //    if (i == closestIndex)
        //    {
        //        itemsHolder.GetChild(closestIndex).GetComponent<ProceduralImage>().color = Color.red;
        //    }
        //    else
        //    {
        //        itemsHolder.GetChild(i).GetComponent<ProceduralImage>().color = Color.white;
        //        itemsHolder.GetChild(i).localScale = new Vector3(1, 1, 1);
        //    }
        //}
        //itemsHolder.GetChild(closestIndex).localScale = Vector3.Lerp(itemsHolder.GetChild(closestIndex).localScale, new Vector3(1.5f, 1.5f, 1.5f), Time.deltaTime * 5f);
        if (inShopSelectedWeapon.MyValue != closestIndex)
        {
            inShopSelectedWeapon.MyValue = closestIndex;
        }
    }
    private void OnDisable()
    {
        LeanTouch.OnFingerUpdate -= DragStore;
        LeanTouch.OnFingerUp -= OnFingerUp;
        LeanTouch.OnFingerDown -= OnFingerDown;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //eventDataPositionX = eventData.position.x;
        //slectedElement = eventData.selectedObject.name;
        //deltaX = eventData.position.x - startPosition.x;
        //itemsHolder.localPosition += new Vector3(deltaX, 0, 0);
        //startPosition = eventData.position;
    }
}
