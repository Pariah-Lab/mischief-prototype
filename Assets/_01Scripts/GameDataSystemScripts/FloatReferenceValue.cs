using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DataSystem
{
    [System.Serializable]
    public class FloatReferenceValue
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatValue Variable;

        public float Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
            set
            {
                if (UseConstant)
                {
                    ConstantValue = value;
                }
                else
                {
                    Variable.MyValue = value;
                }
            }
        }
    } 
}
