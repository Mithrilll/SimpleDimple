using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class RefreshSave : MonoBehaviour
{
    private string mPath;
    public Save mSave;
    public int[] mDefaultTypesOfClickBonuses;
    public int[] mDefaultPricesOfClickBonuses;
    public int[] mDefaultTypesOfAutoClickes;
    public int[] mDefaultPricesOfAutoClickes;


    public void SaveDefault()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        mPath = Path.Combine(Application.dataPath, "Save.json");
#endif

        mSave.score = 0;
        mSave.clickbonus = 1;
        mSave.autoclick = 0;
        for (int i = 0; i < mDefaultTypesOfClickBonuses.Length; i++)
        {
            mSave.typesofclickbonuses[i] = mDefaultTypesOfClickBonuses[i];
            mSave.pricesclickbonuses[i] = mDefaultPricesOfClickBonuses[i];
        }

        for (int i = 0; i < mDefaultTypesOfAutoClickes.Length; i++)
        {
            mSave.typesofautoclickes[i] = mDefaultTypesOfAutoClickes[i];
            mSave.pricesautoclickes[i] = mDefaultPricesOfAutoClickes[i];
        }

        File.WriteAllText(mPath, JsonUtility.ToJson(mSave));
    }

    [Serializable]
    public class Save
    {
        public int score;
        public int clickbonus;
        public int[] typesofclickbonuses;
        public int[] pricesclickbonuses;
        public int autoclick;
        public int[] typesofautoclickes;
        public int[] pricesautoclickes;
    }
}
