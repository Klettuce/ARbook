using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    public GameObject T1;
    public GameObject T2;

    public void OpenT2()
    {
        T2.SetActive(true);
        T1.SetActive(false);
    }
}
