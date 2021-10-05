using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tasks;
using Vocabulary;

public class TasksUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private TaskUI _prefab;

    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _dailyText;

    [SerializeField]
    private Text _weeklyText;

    [SerializeField]
    private Transform _tasksListDaily;
    [SerializeField]
    private Transform _tasksListWeekly;
    private List<TaskUI> _objects;



    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetLanguage(SystemLanguage language)
    {
        _dailyText.text = Words.GetWord(Word.daily, language);
        _weeklyText.text = Words.GetWord(Word.weekly, language);
    }

    public void SetUp(TaskCell[] taskCells, SystemLanguage language, Action[] onRewardClicked)
    {
            foreach (Transform t in _tasksListDaily)
                Destroy(t.gameObject);
                        foreach (Transform t in _tasksListWeekly)
                Destroy(t.gameObject);

            _objects = new List<TaskUI>();
      


        long time = 0;
        bool isNetworkTime = TimeManager.GetNetworkTime(out time);

        for(int i = 0; i < taskCells.Length; i++)
        {
            TaskUI taskUI = Instantiate(_prefab, taskCells[i].taskType == ETaskType.daily ? _tasksListDaily : _tasksListWeekly);
            _objects.Add(taskUI);

            if (taskCells[i].ExistTask)
            {
                taskUI.SetUp(taskCells[i].task.Description(language), Words.GetWord(Word.reward, language),
                    taskCells[i].task.reward.ToString(), taskCells[i].task.Percentage,
                    $"{taskCells[i].task.current} / {taskCells[i].task.target}", taskCells[i].task.rewardType);
            }
            else
            {
                if (isNetworkTime)
                {
                    TimeSpan timeSpan = taskCells[i].NewTaskDate - DateTime.Now;

                    if(taskCells[i].taskType == ETaskType.daily)
                    taskUI.SetUp($"{Words.GetWord(Word.new_task_after, language)}  {timeSpan.ToString(@"h\:mm\:ss")}");
                    else
                        taskUI.SetUp($"{Words.GetWord(Word.new_task_after, language)}  {timeSpan.ToString(@"dd\.hh\:mm\:ss")}");
                }
                else
                {
                    taskUI.SetUp($"{Words.GetWord(Word.network_require, language)}");
                }
            }

            taskUI.OnRewardClicked += onRewardClicked[i];
        }
    } 
}