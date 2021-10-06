using UnityEngine;
using System.IO;
using System;

public class SaveSystem : MonoBehaviour
{
    private string mPath;
    public Save mSave;
    public ScoreCounter mScoreCounter;
    public InterfaceScripts mInterfaceScripts;
    public int[] mDefaultTypesOfClickBonuses;
    public int[] mDefaultPricesOfClickBonuses;
    public int[] mDefaultTypesOfAutoClickes;
    public int[] mDefaultPricesOfAutoClickes;

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        mPath = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        mPath = Path.Combine(Application.dataPath, "Save.json");
#endif
    }

    private void Start()
    {
        if (File.Exists(mPath))
        {
            mSave = JsonUtility.FromJson<Save>(File.ReadAllText(mPath));
        }
        else
        {
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
        }

    }

    public void SaveData()
    {
        mSave.score = mScoreCounter.mScore;
        mSave.clickbonus = mScoreCounter.mBonusClick;
        mSave.autoclick = mScoreCounter.mAutoClick;

        for (int i = 0; i < mInterfaceScripts.mTypesOfClickBonuses.Length; i++)
        {
            mSave.typesofclickbonuses[i] = mInterfaceScripts.mTypesOfClickBonuses[i];
            mSave.pricesclickbonuses[i] = mInterfaceScripts.mPricesOfClickBonuses[i];
        }

        for (int i = 0; i < mInterfaceScripts.mTypesOfAutoClickes.Length; i++)
        {
            mSave.typesofautoclickes[i] = mInterfaceScripts.mTypesOfAutoClickes[i];
            mSave.pricesautoclickes[i] = mInterfaceScripts.mPricesOfAutoClickes[i];
        }

        File.WriteAllText(mPath, JsonUtility.ToJson(mSave));
    }

    public Save LoadData()
    {
        if (File.Exists(mPath))
        {
            mSave = JsonUtility.FromJson<Save>(File.ReadAllText(mPath));
        }

        return mSave;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        mSave.score = mScoreCounter.mScore;
        mSave.clickbonus = mScoreCounter.mBonusClick;
        mSave.autoclick = mScoreCounter.mAutoClick;

        for (int i = 0; i < mInterfaceScripts.mTypesOfClickBonuses.Length; i++)
            {
                mSave.typesofclickbonuses[i] = mInterfaceScripts.mTypesOfClickBonuses[i];
                mSave.pricesclickbonuses[i] = mInterfaceScripts.mPricesOfClickBonuses[i];
            }

        for (int i = 0; i < mInterfaceScripts.mTypesOfAutoClickes.Length; i++)
            {
                mSave.typesofautoclickes[i] = mInterfaceScripts.mTypesOfAutoClickes[i];
                mSave.pricesautoclickes[i] = mInterfaceScripts.mPricesOfAutoClickes[i];
            }

        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        mSave.score = mScoreCounter.mScore;
        mSave.clickbonus = mScoreCounter.mBonusClick;
        mSave.autoclick = mScoreCounter.mAutoClick;

        for (int i = 0; i < mInterfaceScripts.mTypesOfClickBonuses.Length; i++)
        {
            mSave.typesofclickbonuses[i] = mInterfaceScripts.mTypesOfClickBonuses[i];
            mSave.pricesclickbonuses[i] = mInterfaceScripts.mPricesOfClickBonuses[i];
        }

        for (int i = 0; i < mInterfaceScripts.mTypesOfAutoClickes.Length; i++)
        {
            mSave.typesofautoclickes[i] = mInterfaceScripts.mTypesOfAutoClickes[i];
            mSave.pricesautoclickes[i] = mInterfaceScripts.mPricesOfAutoClickes[i];
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