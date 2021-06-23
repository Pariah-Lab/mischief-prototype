using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "UpgradableValue", menuName = "ScriptableObjects/UpgradableValue")]
    public class UpgradableValue : ScriptableObject
    {
        public IntValue level;
        public bool useIntCurve;

        public UpgradeProgressionCurveInt upgradeCurveInt;
        public UpgradeProgressionCurveFloat upgradeCurveFloat;

        public int GetMyValueInt()
        {
            return upgradeCurveInt.GetValueAtLevel(level.Value);
        }
        public float GetMyValueFloat()
        {
            return upgradeCurveFloat.GetValueAtLevel(level.Value);
        }

    }

}