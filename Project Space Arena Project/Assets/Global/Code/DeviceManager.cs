using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _phoneObjects;

    void Start()
    {
//#if UNITY_ANDROID
        foreach (GameObject phoneObject in _phoneObjects)
        {
            phoneObject.SetActive(true);
        }
//#endif
    }
}
