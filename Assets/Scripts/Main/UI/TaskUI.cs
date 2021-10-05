using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField]
    private Text _descriptionText;
    [SerializeField]
    private Text _rewardText;
    [SerializeField]
    private Button _rewardButton;
    [SerializeField]
    private Text _reward;
    [SerializeField]
    private Slider _progressSlider;
    [SerializeField]
    private Text _progress;

    [SerializeField]
    private Transform _newTaskAfter;
    [SerializeField]
    private Text _newTaskAfterText;

    [SerializeField]
    private Transform _rewardEnergy;
    [SerializeField]
    private Transform _rewardMiddleChest;
    [SerializeField]
    private Transform _rewardBigChest;



    public event Action OnRewardClicked;



    public void SetUp(string description, string rewardText, 
        string reward, float progressPrecentage, string progressText, Tasks.ETaskReward rewardType)
    {
        _descriptionText.text = description;
        _rewardText.text = rewardText;
        _reward.text = reward;
        _progressSlider.value = progressPrecentage / 100f;
        _rewardButton.interactable = progressPrecentage >= 100f;
        _progress.text = progressText;
        _newTaskAfter.gameObject.SetActive(false);

        _rewardEnergy.gameObject.SetActive(rewardType == Tasks.ETaskReward.energy);
        _rewardMiddleChest.gameObject.SetActive(rewardType == Tasks.ETaskReward.middleChest);
        _rewardBigChest.gameObject.SetActive(rewardType == Tasks.ETaskReward.bigChest);

        Set();
    }

    public void SetUp(string newTaskAfterText)
    {
        _newTaskAfter.gameObject.SetActive(true);
        _newTaskAfterText.text = newTaskAfterText;

        Set();
    }

    private void Set()
    {
        _rewardButton.onClick.AddListener(() => OnRewardClicked.Invoke());
    }

    private void OnDestroy()
    {
        _rewardButton.onClick.RemoveAllListeners();
    }
}