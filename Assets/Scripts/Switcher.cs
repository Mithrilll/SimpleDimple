using UnityEngine;
using UnityEngine.UI;

public class Switcher : MonoBehaviour
{
    public GameObject[] mButtonsMeshes;
    public GameObject mMainMesh;
    private int mCountOfPressedButtons;
    private bool mIsRotation = false;
    private float mRotatedAngle = 0.0f;

    void Start()
    {
    }

    void Update()
    {
        mCountOfPressedButtons = 0;
        for (int i = 0; i < mButtonsMeshes.Length; i++)
        {
            if (!mButtonsMeshes[i].GetComponent<SphereCollider>().enabled)
                mCountOfPressedButtons++;
        }

        if (mCountOfPressedButtons == mButtonsMeshes.Length)
        {
            mIsRotation = true;
        }

        if(mIsRotation && mRotatedAngle < 180.0f)
        {
            float step = 180.0f/(0.25f/Time.deltaTime);

            if(mRotatedAngle + step > 180.0f)
                mMainMesh.transform.Rotate(180.0f-mRotatedAngle, 0, 0);
            else
                mMainMesh.transform.Rotate(step, 0, 0);

            mRotatedAngle += step;
        }

        if(mRotatedAngle >= 180.0f)
        {
            mIsRotation = false;
            mRotatedAngle = 0.0f;

            for(int i =0; i < mButtonsMeshes.Length; i++)
            {
                mButtonsMeshes[i].GetComponent<SphereCollider>().enabled = true;
            }
        }
    }

    public void ButtonClick(int index)
    {
        if (mButtonsMeshes[index].GetComponent<SphereCollider>().enabled == true)
        {
            mButtonsMeshes[index].transform.Rotate(new Vector3(180, 0, 0));
            mButtonsMeshes[index].GetComponent<SphereCollider>().enabled = false;
        }
    }
}
