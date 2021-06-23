using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DataSystem;
namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "UpgradeHandler", menuName = "ScriptableObjects/UpgradeHandler")]
    public class UpgradeScriptable : ScriptableObject
    {
        public UnityAction OnUpgradeTried;
        public IntReferenceValue currencyInt;
        public IntReferenceValue level;

        //If currency is greater thatn the upgradevalue
        public UpgradeProgressionCurveInt priceCurveUpgradeInt;
        // public UpgradeProgressionCurveInt priceCurveUpgradeFloat;

        public void Upgrade()
        {

            if (currencyInt.Variable.MyValue - priceCurveUpgradeInt.GetValueAtLevel(level.Variable.MyValue) >= 0)
            {
                currencyInt.Variable.MyValue -= priceCurveUpgradeInt.GetValueAtLevel(level.Variable.MyValue);
                level.Variable.MyValue++;
            }
            else
            {
                //Debug.Log("Not enough money");
            }
            OnUpgradeTried?.Invoke();
        }
        public void ManualForcedUpgrade()
        {
            level.Variable.MyValue++;
        }
        public bool CanUpgrade()
        {
            int value = priceCurveUpgradeInt.GetValueAtLevel(level.Variable.MyValue);
            if (currencyInt.Variable.MyValue - value >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}