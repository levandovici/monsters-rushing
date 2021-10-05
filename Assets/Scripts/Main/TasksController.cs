using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Tasks;
using System;

public class TasksController : MonoBehaviour
{
    public event Func<TaskCell[]> OnTasksNeed;
    public event Action<int> OnTaskIDReward;
    public event Action<TaskCell[], SystemLanguage, Action[]> OnUpdateUI;

    private SystemLanguage _language;


    public void SetUp(SystemLanguage language)
    {
        _language = language;
    }

    private void Start()
    {
        StartCoroutine(Updater());
    }


    private IEnumerator Updater()
    {
        while (true)
        {
            UpdateNow();
            yield return new WaitForSeconds(1f);
        }
    }


    public void UpdateNow()
    {
        TaskCell[] cells = OnTasksNeed.Invoke();
        Action[] actions = new Action[cells.Length];

        for (int i = 0; i < actions.Length; i++)
        {
            int n = i;
            actions[i] = () =>
            {
                OnTaskIDReward(n);
            };
        }

        OnUpdateUI.Invoke(cells, _language, actions);
    }
}