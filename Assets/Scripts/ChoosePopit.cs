using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePopit : MonoBehaviour
{
    public GameObject[] objects;

    public void Choose(int index)
    {
        for (int i = 0; i < objects.Length; i++)
            objects[i].SetActive(false);

        objects[index].SetActive(true);
    }
}
