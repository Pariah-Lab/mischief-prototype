using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

/// <summary>
/// Various utility functions. 
/// </summary>
public static class Utility
{

    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;
    }
    public static int GetRandomIndex<T>(List<T> list)
    {
        int index = UnityEngine.Random.Range(0, list.Count);

        return index;
    }
    public static float LerpCustom(float a, float b, float t)
    {
        return (1.0f - t) * a + b * t;
    }
    public static float InverseLerpCUstom(float a, float b, float v)
    {
        return (v - a) / (b - a);
    }
    /// <summary>
    /// Takes two input parameters(iMin, iMax) and remaps those values to 
    /// oMin and oMax by v.
    /// if v == iMin output = oMin
    /// if v == iMax output = oMax
    /// </summary>    
    public static float RemapValues(float iMin, float iMax, float oMin, float oMax, float v)
    {
        float t = InverseLerpCUstom(iMin, iMax, v);
        return LerpCustom(oMin, oMax, t);
    }
    public static void DebugText(string message, string color)
    {
        if (Application.isEditor)
            Debug.Log("<color=" + color + ">" + "#SliceItLOG_ " + message + "</color>");
    }
    public static void DebugText(string message)
    {
        if (Application.isEditor)
            Debug.Log("<color=" + "red" + ">" + "#" + "</color>" + "<color=" + "white" + ">" + "SliceItLOG_ " + message + "</color>");
    }
    public static void DebugText(string message, object sender = null)
    {
        if (Application.isEditor)
            if (sender != null)
            {
                Debug.Log("<color=" + "red" + ">" + "#" + "</color>" + "<color=" + "white" + ">" + "SliceItLOG_ " + message + "  sender: " + sender + "</color>"); 
            }
            else
            {
                Debug.Log("<color=" + "red" + ">" + "#" + "</color>" + "<color=" + "white" + ">" + "SliceItLOG_ " + message + "</color>");
            }
    }
    public static void DebugText(string message, string color, object sender = null)
    {
        if (Application.isEditor)
            if (sender != null)
            {
                Debug.Log("<color=" + color + ">" + "#" + "</color>" + "<color=" + color + ">" + "SliceItLOG_ " + message + "  sender: " + sender + "</color>");
            }
            else
            {
                Debug.Log("<color=" + color + ">" + "#" + "</color>" + "<color=" + color + ">" + "SliceItLOG_ " + message + "</color>");
            }
    }
    public static bool RandomPositionOnNavmesh(Vector3 sourcePosition, out Vector3 hitPos)
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        Vector3 samplePoint = sourcePosition + new Vector3(randomPoint.x, 0, randomPoint.y) * Random.Range(0, 120f);
        NavMeshHit navHit;
        if (NavMesh.SamplePosition(samplePoint, out navHit, 50f, NavMesh.AllAreas))
        {
            hitPos = navHit.position;
            return true;
        }
        else
        {
            hitPos = sourcePosition;
            return false;
        }
        
    }
    public static float PerlinNoiseRandomizator(float time)
    {
        return Mathf.PerlinNoise(time + 0.2f, time);
    }
    public static Vector3 GetTerrainPosition(Vector3 pos, LayerMask layer)
    {
        Debug.DrawRay(new Vector3(pos.x, 50f, pos.z), Vector3.down, Color.blue, 20f);
        if (Physics.Raycast(new Vector3(pos.x, 50f, pos.z), Vector3.down, out RaycastHit hitinfo, 2000f, layer))
        {
            return hitinfo.point;
        }
        return pos;
    }
    public static Quaternion RotateMyAxisWithThisDirection(Vector3 directionTOMatch, Vector3 axisToMatchWithDirection, Transform rotatedObject)
    {

        #region OldRotationExamples
        // Vector3 directionToHitpoint = rotateTowardsMe.transform.position - gameObject.transform.position;
        // float angleDifference = Vector3.Angle(gameObject.transform.forward, directionToHitpoint);
        // Vector3 cross = Vector3.Cross(gameObject.transform.forward, directionToHitpoint);
        // Quaternion tmp = Quaternion.FromToRotation(gameObject.transform.forward, cross * angleDifference);
        // Quaternion tmp = Quaternion.FromToRotation(gameObject.transform.forward, rotateTowardsMe.transform.position);

        // gameObject.transform.rotation = Quaternion.Euler(tmp.x, rotateTowardsMe.transform.rotation.y, 0f);
        //Which axis to match the direction towards game object
        //Quaternion fromToROtation = Quaternion.FromToRotation(fromRotationAxis, rotateTowardsMe.transform.position - gameObject.transform.position);  
        #endregion


        //direction from object
        Debug.DrawRay(rotatedObject.position, directionTOMatch * 15f, Color.white);
        Debug.DrawRay(rotatedObject.position, (rotatedObject.position + axisToMatchWithDirection) * 15f, Color.blue);

        Vector3 crossDirection = Vector3.Cross(directionTOMatch, axisToMatchWithDirection);

        Debug.DrawRay(rotatedObject.position, crossDirection * 15f, Color.black);

        Quaternion fromTOCrossRotation = Quaternion.FromToRotation(axisToMatchWithDirection, crossDirection);

        return fromTOCrossRotation;

        // gameObject.transform.rotation = fromToROtation;   



        // Vector3 crossDirection = Vector3.Cross(fromRotationAxis, crossAxisMain);
        // gameObject.transform.rotation = Quaternion.FromToRotation(axisFromTOMatchCross, crossDirection);
    }
    public static void MatchAxisTODirection(Transform rotor, Vector3 myAxis, Vector3 toThisdirection)
    {
        Vector3 toCrosswith = Vector3.zero;
        if (myAxis.x == 1)
        {
            //choose up
            toCrosswith = rotor.up;
        }
        if (myAxis.y == 1)
        {
            toCrosswith = rotor.right;
        }
        if (myAxis.z == 1)
        {
            toCrosswith = rotor.up;
        }
        if (myAxis.x == -1)
        {
            toCrosswith = -rotor.up;
        }
        if (myAxis.y == -1)
        {
            toCrosswith = -rotor.right;
        }
        if (myAxis.z == -1)
        {
            toCrosswith = -rotor.up;
        }
        Vector3 cross1 = Vector3.Cross(toThisdirection, toCrosswith);
        //Vector3 cross2 = Vector3.Cross(cross1, toCrosswith);
        //rotor.up = Vector3.Lerp(rotor.up, -Vector3.Cross(cross1, toCrosswith), Time.deltaTime * 5f);
        rotor.up = - Vector3.Cross(cross1, toCrosswith);
    }

    public static void DirectROtation(Transform rotatedObject, Vector3 rotateTowardsMe, Vector3 crossDirectionWithme, Vector3 axisToMatchTheCross)
    {
        Vector3 rotatedTowardsMeCorrected = new Vector3(rotateTowardsMe.x, rotateTowardsMe.y, rotateTowardsMe.z);
        rotateTowardsMe = rotatedTowardsMeCorrected;
        //Debug.DrawRay(rotatedObject.position, (rotateTowardsMe - rotatedObject.position).FlattenedXY() * 15f, Color.white);
        //Debug.DrawRay(rotatedObject.position, (rotatedObject.position + crossDirectionWithme).FlattenedXY() * 15f, Color.red);


        Vector3 crossDirection = Vector3.Cross((rotateTowardsMe - rotatedObject.position), rotatedObject.forward);

        //Debug.DrawRay(rotatedObject.position, crossDirection * 15f, Color.black);

        Quaternion fromTOCrossRotation = Quaternion.FromToRotation(axisToMatchTheCross, -Vector3.Cross(crossDirection, crossDirectionWithme));

        rotatedObject.rotation = fromTOCrossRotation;
    }
    public static int[] GetRandomChunksFOrLoop(int totalNumber, int chunksNumber)
    {
        int equalRes = totalNumber / chunksNumber;
        int[] resultingArray = new int[chunksNumber];
        int current = 0;
        int next = equalRes;
        int chunkCOunter = 0;
        //Setting equals
        for (int i = 0; i < totalNumber; i++)
        {
            if (i == next)
            {
                resultingArray[chunkCOunter] = i;
                next += equalRes;
                chunkCOunter++;
                if (chunkCOunter > resultingArray.Length-1)
                {
                    chunkCOunter = resultingArray.Length - 1;
                }
                if (next + equalRes > totalNumber)
                {
                    next = totalNumber;
                }
            }
        }
        int hasJackpot = 0;
        next = resultingArray[1];
        current = 0;
        //Randomizing chunks
        for (int i = 0; i < resultingArray.Length-1; i++)
        {
            if (Random.Range(0, 100) < 50)
            {
                //Reduce next element down
                if (i + 1 < resultingArray.Length -1)
                {
                    resultingArray[i + 1] = (resultingArray[i + 1] - Random.Range(1, (resultingArray[i + 1] - resultingArray[i]) - 1)); 
                }
            }
        }
       
        return resultingArray;
    }
    public static int[] GetEqualChunks(int totalNumber, int chunksNumber)
    {
        int equalRes = totalNumber / chunksNumber;
        int[] resultingArray = new int[chunksNumber];
        int current = 0;
        int next = equalRes;
        int chunkCOunter = 0;
        //Setting equals
        for (int i = 0; i <= totalNumber; i++)
        {
            if (i == next)
            {
                resultingArray[chunkCOunter] = i;
                next += equalRes;
                chunkCOunter++;
                if (chunkCOunter > resultingArray.Length - 1)
                {
                    chunkCOunter = resultingArray.Length - 1;
                }
                if (next >= totalNumber)
                {
                    next = totalNumber;
                }
            }
        }
        return resultingArray;
    }
    
    public static Bounds GetMaxBoundsOmniKnowing(GameObject g)
    {
        var renderers = g.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return new Bounds(g.transform.position, Vector3.zero);
        var b = renderers[0].bounds;
        foreach (Renderer r in renderers)
        {
            b.Encapsulate(r.bounds);
        }
        return b;
    }
}

public static class ExtensionMethods
{

    //public static Vector3 NavMeshRandomPosition(this NavMesh mesh)
    //{
    //    Vector2 randomPoint = Random.insideUnitCircle;
    //    Vector3 samplePoint = new Vector3(randomPoint.x, 0, randomPoint.y) * Random.Range(0, 20f);
    //    NavMeshHit navHit;
    //    NavMesh.SamplePosition(samplePoint, out navHit, 20f, -1);
    //    return navHit.position;
    //}
    //public static GameObject OnDisableCallback(this GameObject go, UnityAction callback)
    //{
    //    go.OnDestroy += ;
    //}
    //public static bool CompareMYTaggable(this GameObject go, string comparer)
    //{
    //    Taggable tgb = go.GetComponent<Taggable>();
    //    if (tgb != null && tgb.CompareMyTag(comparer))
    //    {
    //        return true;
    //    }
    //    else { return false; }
    //}
    public static bool IsInMask(this int layer, LayerMask mask)
    {
        return ((1 << layer) & mask.value) != 0;
    }
    public static int GetSelectedLayer(this LayerMask layer)
    {
        int val = (int)layer.value;
        int res = 0;
        if (val == 0)
            res = -1;
        for (int i = 0; i < 32; i++)
        {
            if ((val & (1 << i)) != 0)
                res = i;
        }
        return res;
    }
   
    public static IEnumerator OnComplete(this MonoBehaviour i, UnityAction OnComplete)
    {
        OnComplete?.Invoke();
        return null;
    }
    public static IEnumerator OnCompleteDelay(this MonoBehaviour i, UnityAction OnComplete, float delay)
    {
        yield return new WaitForSeconds(delay);
        OnComplete?.Invoke();
        
    }
    public static Vector3 RandomDirection(this Vector3 v, Vector3 startingPoint)
    {
        Vector2 random = Random.insideUnitCircle;
        Vector3 result = startingPoint + new Vector3(random.x, startingPoint.y, random.y);
        return result;
    }
    public static Vector2 xy(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }
    public static Vector3 LerpMe(this Vector3 v, Vector3 final, float time)
    {
        v = Vector3.Lerp(v, final, time);
        return v;
    }

    public static Vector3 WithX(this Vector3 v, float x)
    {
        return new Vector3(x, v.y, v.z);
    }

    public static Vector3 WithY(this Vector3 v, float y)
    {
        return new Vector3(v.x, y, v.z);
    }

    public static Vector3 WithZ(this Vector3 v, float z)
    {
        return new Vector3(v.x, v.y, z);
    }

    public static Vector2 WithX(this Vector2 v, float x)
    {
        return new Vector2(x, v.y);
    }
    
    public static Vector2 WithY(this Vector2 v, float y)
    {
        return new Vector2(v.x, y);
    }

    public static Vector3 WithZ(this Vector2 v, float z)
    {
        return new Vector3(v.x, v.y, z);
    }
    public static Vector3 RandomizeX(this Vector3 v, float lateralMovement)
    {
        return new Vector3(Random.Range(-lateralMovement, lateralMovement), v.y, v.z);
    }
    public static Vector3 ONE(this Vector3 v)
    {
        return new Vector3(1, 1, 1);
    }
    // axisDirection - unit vector in direction of an axis (eg, defines a line that passes through zero)
    // point - the point to find nearest on line for
    public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
    {
        if (!isNormalized)axisDirection.Normalize();
        var d = Vector3.Dot(point, axisDirection);
        return axisDirection * d;
    }

    // lineDirection - unit vector in direction of line
    // pointOnLine - a point on the line (allowing us to define an actual line in space)
    // point - the point to find nearest on line for
    public static Vector3 NearestPointOnLine(
        this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false)
    {
        if (!isNormalized)lineDirection.Normalize();
        var d = Vector3.Dot(point - pointOnLine, lineDirection);
        return pointOnLine + (lineDirection * d);
    }
    public static Vector3 WithAddX(this Vector3 v, float x)
    {
        return new Vector3(v.x + x, v.y, v.z);
    }

    public static Vector3 WithAddY(this Vector3 v, float y)
    {
        return new Vector3(v.x, v.y + y, v.z);
    }

    public static Vector3 WithAddZ(this Vector3 v, float z)
    {
        return new Vector3(v.x, v.y, v.z + z);
    }
    public static Vector2 WithAddX(this Vector2 v, float x)
    {
        return new Vector2(v.x + x, v.y);
    }
    public static Vector2 WithAddY(this Vector2 v, float y)
    {
        return new Vector2(v.x, v.y + y);
    }
    public static Vector3 Flattened(this Vector3 vector)
    {
        return new Vector3(vector.x, 0f, vector.z);
    }
    public static Vector3 FlattenedXZ(this Vector3 vector)
    {
        return new Vector3(vector.x, 0f, vector.z);
    }
    public static Vector3 FlattenedXY(this Vector3 vector)
    {
        return new Vector3(vector.x, vector.y, 0f);
    }
    public static Vector3 FlattenedZY(this Vector3 vector)
    {
        return new Vector3(0f, vector.y, vector.z);
    }

    public static float DistanceFlat(this Vector3 origin, Vector3 destination)
    {
        return Vector3.Distance(origin.Flattened(), destination.Flattened());
    }
}