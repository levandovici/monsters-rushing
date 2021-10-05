using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Vocabulary;

namespace Tasks
{
    [System.Serializable]
    public class Task
    {
        public ETaskPoint point;
        public int current;
        public int target;
        public ETaskReward rewardType;
        public int reward;
        


        public float Percentage => current / target * 100f;



        public Task(ETaskPoint point, int target, ETaskReward rewardType, int reward)
        {
            this.point = point;
            this.current = 0;
            this.target = target;
            this.rewardType = rewardType;
            this.reward = reward;
        }



        public string Description(SystemLanguage language)
        {
            if(point == ETaskPoint.collect_water)
            {
                return Words.GetWord(Word.collect_gems, language);
            }
            else if (point == ETaskPoint.damage)
            {
                return Words.GetWord(Word.deal_damage, language);
            }
            else if (point == ETaskPoint.kills)
            {
                return Words.GetWord(Word.kill_monsters, language);
            }
            else if (point == ETaskPoint.kill_zombies)
            {
                return Words.GetWord(Word.kill_zombies, language);
            }
            else
            {
                throw new NotImplementedException();
            }
        }



        public static Task GenerateTasks(ETaskType taskType)
        {
            if (taskType == ETaskType.daily)
            {
                int r = UnityEngine.Random.Range(0, 4);

                ETaskPoint point = ETaskPoint.collect_water;

                int targetCount = 0;
                int reward = 0;
                if (r == 0)
                {
                    point = ETaskPoint.collect_water;
                    targetCount = UnityEngine.Random.Range(5, 16) * 3000;
                    reward = targetCount / 3000;
                }
                else if (r == 1)
                {
                    point = ETaskPoint.damage;
                    targetCount = UnityEngine.Random.Range(5, 16) * 500;
                    reward = targetCount / 250;
                }
                else if (r == 2)
                {
                    point = ETaskPoint.kill_zombies;
                    targetCount = UnityEngine.Random.Range(5, 16);
                    reward = targetCount * 2;
                }
                else
                {
                    point = ETaskPoint.kills;
                    targetCount = UnityEngine.Random.Range(5, 16);
                    reward = targetCount * 2;
                }


                return new Task(point, targetCount, ETaskReward.energy, reward);
            }
            else
            {
                int r = UnityEngine.Random.Range(0, 4);

                ETaskPoint point = ETaskPoint.collect_water;

                int targetCount = 0;
                int reward = 0;
                if (r == 0)
                {
                    point = ETaskPoint.collect_water;
                    targetCount = UnityEngine.Random.Range(75, 100) * 3000;
                }
                else if (r == 1)
                {
                    point = ETaskPoint.damage;
                    targetCount = UnityEngine.Random.Range(75, 100) * 500;
                }
                else if (r == 2)
                {
                    point = ETaskPoint.kill_zombies;
                    targetCount = UnityEngine.Random.Range(75, 100);
                }
                else
                {
                    point = ETaskPoint.kills;
                    targetCount = UnityEngine.Random.Range(75, 100);
                }

                ETaskReward rewardType = UnityEngine.Random.Range(0, 4) == 0 ? ETaskReward.bigChest : ETaskReward.middleChest;
                reward = rewardType == ETaskReward.bigChest ? 1 : UnityEngine.Random.Range(0, 2) == 0 ? 2 : 1;  

                return new Task(point, targetCount,rewardType, reward);
            }

            throw new NotImplementedException();
        }
    }



    public enum ETaskPoint
    {
        kills, damage, collect_water, kill_zombies,
    }

    public enum ETaskReward
    {
        energy, middleChest, bigChest,
    }


    public enum ETaskType
    {
        daily, weekly,
    }


    [System.Serializable]
    public class TaskCell
    {
        public Task task;
        public long newDateTime;
        public ETaskType taskType;



        public bool ExistTask => task != null && task.reward > 0 && task.target > 0;

        public DateTime NewTaskDate => new DateTime(newDateTime);



        public TaskCell(Task task, ETaskType taskType, DateTime newTaskDate)
        {
            this.task = task;
            this.newDateTime = newTaskDate.Ticks;
            this.taskType = taskType;
        }



        public int Reward()
        {
            if (task != null)
            {
                int r = task.reward;
                task = null;

                return r;
            }

            return 0;
        }
    }



    public static class TasksHelper
    {
        public static void Trigger(ETaskPoint point, int count)
        {
            TaskCell[] taskCells = SaveLoadManager.Current.tasks;

            foreach (TaskCell task in taskCells)
            {
                if (task.ExistTask && task.task.point == point)
                {
                    task.task.current = 
                        Mathf.Clamp(task.task.current + count,
                        task.task.current, task.task.target);
                }
            }
        }
    }
}