using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DynamicObject
    : MonoBehaviour
{
    GameObject cube = null;


    public void CreateCube()
    {
        if (!cube)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(transform);
        }
    }

    public void DestroyCube()
    {
        Destroy(cube);
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }

    public void DestroyImmediateMyself()
    {
        DestroyImmediate(gameObject);
    }

    public void DestroyMyselfDelay(float time)
    {
        Invoke("DestroyMyself", time);
    }


    private void Start()
    {
        Debug.Log(gameObject.name + " is " + MethodInfo.GetCurrentMethod().Name);
    }

    private void OnEnable()
    {
        Debug.Log(gameObject.name + " is " + MethodInfo.GetCurrentMethod().Name);
    }

    private void OnDisable()
    {
        Debug.Log(gameObject.name + " is " + MethodInfo.GetCurrentMethod().Name);
    }

    private void OnDestroy()
    {
        Debug.Log(gameObject.name + " is " + MethodInfo.GetCurrentMethod().Name);
    }
}
