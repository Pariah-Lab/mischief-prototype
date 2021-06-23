using DataSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class ShopItemsHandler : MonoBehaviour
{
    [SerializeField] RectTransform myRect;
    [SerializeField] List<WeaponSettings> existingWeapons;
    [SerializeField] GameObject weaponDisplayImg;
    [SerializeField] IntValue inShopSelectedItem;
    [SerializeField] IntValue selectedWeapon;
    [SerializeField] float xDistanceOfElements = 500f;
    [SerializeField] Image bigWeaponSpriteHolder;
    [SerializeField] Button selectButton;
    void OnEnable()
    {
        if (transform.childCount != existingWeapons.Count)
        {
            for (int i = 0; i < existingWeapons.Count; i++)
            {
                GameObject tmp = Instantiate(weaponDisplayImg, new Vector3((i * xDistanceOfElements), 0, 0), Quaternion.identity, myRect);
                tmp.transform.localPosition = new Vector3((i * xDistanceOfElements), 0, 0);
                //tmp.GetComponent<ProceduralImage>().sprite = existingWeapons[i].weaponImg;
            }
        }
            inShopSelectedItem.MyValueChanged += SelectedItemChanged;
        SelectedItemChanged(inShopSelectedItem.MyValue);
    }

    void SelectedItemChanged(int index)
    {
        bigWeaponSpriteHolder.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //bigWeaponSpriteHolder.sprite = existingWeapons[index].weaponImg;
        if (!existingWeapons[index].unlocked)
        {
            selectButton.interactable = false;
        }
        else
        {
            selectButton.interactable = true;
        }
        StartCoroutine(WeaponScaler());
    }
    public void SelectWeapon()
    {
        selectedWeapon.MyValue = inShopSelectedItem.MyValue;
    }
    IEnumerator WeaponScaler()
    {
        float counter = 0;
        while (counter <= 0.3f)
        {
            counter += Time.deltaTime;
            bigWeaponSpriteHolder.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1f, 1f, 1f), Utility.RemapValues(0f, 0.3f, 0f, 1f, counter));
            yield return null;
        }

    }

    private void OnDisable()
    {
        inShopSelectedItem.MyValueChanged -= SelectedItemChanged;
    }
}
