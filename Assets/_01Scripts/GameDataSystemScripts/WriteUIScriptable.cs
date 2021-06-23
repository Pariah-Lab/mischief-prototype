using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DataSystem;
[System.Serializable]
public class WriteUIScriptable : MonoBehaviour
{
    public TMP_Text myTextField;
    public bool useSlider;
    public bool useDefault;
    public Slider defaultSlider;
    public Image fillImage;
    public bool useInt;
    public bool animateValueChage;
    public bool usePrefix;
    public bool useSufix;
    public bool useCurve;
    public string prefix;
    public string suFix;
    public FloatReferenceValue floatValue;
    public IntReferenceValue intValue;

    [SerializeField] UnityEvent OnValueChanged;

    public bool intCurve;
    public UpgradeProgressionCurveInt progressionCurveInt;
    public UpgradeProgressionCurveFloat progressionCurveFloat;


    [SerializeField] public UnityEvent OnValueUpdated;

    public bool autSubscribe;

    private float oldValue;
    private void OnEnable()
    {
        if (autSubscribe)
        {
            ReadValueOnChange();
            if (!useInt && !floatValue.UseConstant)
            {
                floatValue.Variable.MyValueChanged += MyValueChangedListenerFloat;
            }
            if (useInt && !intValue.UseConstant)
            {
                intValue.Variable.MyValueChanged += MyValueChangedListenerInt;
            } 
        }
    }
    public void SetMeUp()
    {
        ReadValueOnChange();
        if (!useInt && !floatValue.UseConstant)
        {
            floatValue.Variable.MyValueChanged += MyValueChangedListenerFloat;
        }
        if (useInt && !intValue.UseConstant)
        {
            intValue.Variable.MyValueChanged += MyValueChangedListenerInt;
        }
    }
    private void MyValueChangedListenerFloat(float value)
    {
        OnValueChanged?.Invoke();
        if (useSlider)
        {
            SetSlider(floatValue.Value);
            return;
        }
        if (!animateValueChage)
        {
            SetText(prefix, floatValue.Variable.MyValue.ToString("f1"), suFix);
        }
        else
        {
            StartCoroutine(ValueUpdate(value));
        }
    }
    private void MyValueChangedListenerInt(int value)
    {
        OnValueChanged?.Invoke();
        if (useSlider)
        {
            SetSlider(floatValue.Value);
            return;
        }
        if (!animateValueChage)
        {
            if (!useCurve)
            {
                SetText(prefix, intValue.Variable.MyValue.ToString(), suFix);
            }
            else
            {
                if (intCurve)
                {
                    SetText(prefix, progressionCurveInt.GetValueAtLevel(intValue.Variable.MyValue).ToString(), suFix);
                }
                else
                {
                    SetText(prefix, progressionCurveFloat.GetValueAtLevel(intValue.Variable.MyValue).ToString("f1"), suFix);

                }

            }
        }
        else
        {
            StartCoroutine(ValueUpdate(value));
        }
    }
    //expects game data event to trigger the change;
    public void ReadValueOnChange()
    {
        if (useSlider)
        {
            SetSlider(floatValue.Value);
            return;
        }
        if (!animateValueChage)
        {
            if (!useInt)
            {
                SetText(prefix, floatValue.Variable.MyValue.ToString("f1"), suFix);
            }
            else
            {
                if (!useCurve)
                {
                    SetText(prefix, intValue.Variable.MyValue.ToString(), suFix);
                }
                else
                {
                    if (intCurve)
                    {
                        SetText(prefix, progressionCurveInt.GetValueAtLevel(intValue.Variable.MyValue).ToString(), suFix);
                    }
                    else
                    {
                        SetText(prefix, progressionCurveFloat.GetValueAtLevel(intValue.Variable.MyValue).ToString("f1"), suFix);

                    }
                }
            }
        }
        else
        {
            if (!useInt)
            {
                StartCoroutine(ValueUpdate(floatValue.Value));
            }
            else
            {
                StartCoroutine(ValueUpdate(intValue.Value));
            }
        }
    }
    private void SetSlider(float sliderValue)
    {
        if (useDefault)
        {
            defaultSlider.value = sliderValue;
        }
        else
        {
            fillImage.fillAmount = sliderValue;
        }
    }
    private void SetText(string prefix, string value, string suffix)
    {
        myTextField.text = prefix + value + suffix;
    }
    private void OnDisable()
    {
        if (!useInt && !floatValue.UseConstant)
        {
            floatValue.Variable.MyValueChanged -= MyValueChangedListenerFloat;
        }
        if (useInt && !intValue.UseConstant)
        {
            intValue.Variable.MyValueChanged -= MyValueChangedListenerInt;
        }
    }
    public IEnumerator ValueUpdate(float newValue)
    {

        while (oldValue < newValue)
        {
            oldValue+= 5;
            myTextField.text = oldValue.ToString();
            OnValueUpdated?.Invoke();
            yield return new WaitForSeconds(0.03f);
        }
    }

}