using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceScripts : MonoBehaviour
{
    public GameObject[] shopPanels;

    public int[] ClickBonus;
    public int[] ClickBonusCost;
    public Text[] TextClickBonusCost;
    public int autoBonus = 0;
    float time1 = 0;

    public ScoreCounter Score;


    public void Close_Open_ShopPanels(int index)
    {

        for (int i = 0; i < shopPanels.Length; i++)
        {
            if (shopPanels[i].activeSelf)
            {
                shopPanels[i].SetActive(false);

                if (i == index)
                {
                    return;
                }
            }
        }

        if (index != 4)
        {
            shopPanels[index].SetActive(true);
        }

    }

    public void AddBonus(int index)
    {
        if (Score.Score >= ClickBonusCost[index])
        {
            Score.bonus += ClickBonus[index];
            Score.Score -= ClickBonusCost[index];
            ClickBonusCost[index] *= 2;
            TextClickBonusCost[index].text = ClickBonusCost[index] + "кликов";
            Score.UpdateText();
        }
    }

    public void BuyAutoclickBonus()
    {
        if (Score.Score >= 40)
        {
            autoBonus++;
            Score.Score -= 40;
        }
    }

    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - time1 > 1.0f)
        {
            Score.Score += autoBonus;
            time1 = Time.realtimeSinceStartup;
            Score.UpdateText();
        }

    }

}
