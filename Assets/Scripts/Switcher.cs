using UnityEngine;
using UnityEngine.UI;

public class Switcher : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject main;
    public AudioSource collectAudio;
    private int cnt;
    private bool isRotation = false;
    private float angle = 0.0f;

    void Start()
    {
    }

    void Update()
    {
        cnt = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            if (!objects[i].GetComponent<SphereCollider>().enabled)
                cnt++;
        }

        if (cnt == objects.Length)
        {
            isRotation = true;
        }

        if(isRotation && angle < 180.0f)
        {
            float step = 180.0f/(0.25f/Time.deltaTime);

            if(angle + step > 180.0f)
                main.transform.Rotate(180.0f-angle, 0, 0);
            else
                main.transform.Rotate(step, 0, 0);

            angle += step;
        }

        if(angle >= 180.0f)
        {
            isRotation = false;
            angle = 0.0f;

            for(int i =0; i < objects.Length; i++)
            {
                objects[i].GetComponent<SphereCollider>().enabled = true;
            }
        }
    }

    public void ButtonClick(int index)
    {
        if (objects[index].GetComponent<SphereCollider>().enabled == true)
        {
            collectAudio.Play();
            objects[index].transform.Rotate(new Vector3(180, 0, 0));
            objects[index].GetComponent<SphereCollider>().enabled = false;
        }
    }
}
