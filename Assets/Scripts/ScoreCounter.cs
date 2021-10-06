using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int mScore;
    public Text mScoreText;
    public int mBonusClick;
    public int mAutoClick;
    public SaveSystem mSaveSystem;

    private float mLastTime;

    private void Awake()
    {
        mScore = mSaveSystem.LoadData().score;
        mBonusClick = mSaveSystem.LoadData().clickbonus;
        mAutoClick = mSaveSystem.LoadData().autoclick;
        mScoreText.text = mScore.ToString();
        mLastTime = Time.realtimeSinceStartup;

        UpdateText();
    }

    private void Start()
    {
        mScore = mSaveSystem.LoadData().score;
        mBonusClick = mSaveSystem.LoadData().clickbonus;
        mAutoClick = mSaveSystem.LoadData().autoclick;
        mScoreText.text = mScore.ToString();
        mLastTime = Time.realtimeSinceStartup;

        UpdateText();
    }

    private void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - mLastTime > 1.0f)
        {
            mScore += mAutoClick;
            mLastTime = Time.realtimeSinceStartup;
        }

        UpdateText();
    }

    public void UpdateText()
    {
        mScoreText.text = mScore.ToString();
    }

    public void Count()
    {
        mScore += mBonusClick;
    }


}
