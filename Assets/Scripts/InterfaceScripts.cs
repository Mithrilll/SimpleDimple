using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScripts : MonoBehaviour
{
    public GameObject[] mShopPanels;
    public int[] mTypesOfClickBonuses;
    public int[] mPricesOfClickBonuses;
    public Text[] mTextForPricesOfClickBonunses;
    public int[] mTypesOfAutoClickes;
    public int[] mPricesOfAutoClickes;
    public Text[] mTextForPricesOfAutoClickes;
    public ScoreCounter mScoreCounter;
    public SaveSystem mSaveSystem;

    private void Awake()
    {
        for(int i =0; i < mSaveSystem.LoadData().typesofclickbonuses.Length; i++)
        {
            mTypesOfClickBonuses[i] = mSaveSystem.LoadData().typesofclickbonuses[i];
            mPricesOfClickBonuses[i] = mSaveSystem.LoadData().pricesclickbonuses[i];
        }

        for (int i = 0; i < mSaveSystem.LoadData().typesofautoclickes.Length; i++)
        {
            mTypesOfAutoClickes[i] = mSaveSystem.LoadData().typesofautoclickes[i];
            mPricesOfAutoClickes[i] = mSaveSystem.LoadData().pricesautoclickes[i];
        }
    }

    private void Start()
    {
        for(int i =0; i < mTypesOfClickBonuses.Length; i++)
            mTextForPricesOfClickBonunses[i].text = mPricesOfClickBonuses[i].ToString() + " кликов";

        for (int i = 0; i < mTypesOfAutoClickes.Length; i++)
            mTextForPricesOfAutoClickes[i].text = mPricesOfAutoClickes[i].ToString() + " кликов";
    }

    public void Close_Open_ShopPanels(int index)
    {

        for (int i = 0; i < mShopPanels.Length; i++)
        {
            if (mShopPanels[i].activeSelf)
            {
                mShopPanels[i].SetActive(false);

                if (i == index)
                {
                    return;
                }
            }
        }

        if (index != 4)
        {
            mShopPanels[index].SetActive(true);
        }

    }

    public void BuyClickBonus(int index)
    {
        if (index < 0 && index > mTypesOfAutoClickes.Length)
            return;

        if (mScoreCounter.mScore >= mPricesOfClickBonuses[index])
        {
            mScoreCounter.mBonusClick += mTypesOfClickBonuses[index];
            mScoreCounter.mScore -= mPricesOfClickBonuses[index];
            mPricesOfClickBonuses[index] *= 2;
            mTextForPricesOfClickBonunses[index].text = mPricesOfClickBonuses[index].ToString() + " кликов";
            mScoreCounter.UpdateText();
        }
    }

    public void BuyAutoClick(int index)
    {
        if (index < 0 && index > mTypesOfAutoClickes.Length)
            return;

        if (mScoreCounter.mScore >= mPricesOfAutoClickes[index])
        {
            mScoreCounter.mAutoClick += mTypesOfAutoClickes[index];
            mScoreCounter.mScore -= mPricesOfAutoClickes[index];
            mPricesOfAutoClickes[index] *= 2;
            mTextForPricesOfAutoClickes[index].text = mPricesOfAutoClickes[index].ToString() + " кликов";
            mScoreCounter.UpdateText();
        }
    }
}
