using System.Collections;
using System;
using TMPro;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Change Worklog Page Task", menuName = "Tasks/Computer/Change Worklog Page")]
    public sealed class ChangeWorklogPageTask : WorklogTask {
        [SerializeField] private int direction;
        private static int currentPage;
        public static int CurrentPage => currentPage;

        public override IEnumerator Execute(Computer computer) {
            Worker[] workers = computer.Workers;
            GameObject[] icons = computer.WorklogIcons;
            int pageCount = (workers.Length + icons.Length - 1) / icons.Length;

            if(direction == 0)
                currentPage = 0;
            else
                currentPage = Mathf.Clamp(currentPage + direction, 0, Math.Max(pageCount - 1, 0));

            for(int i = 0; i < icons.Length; i++) {
                int workerIndex = currentPage * icons.Length + i;
                icons[i].SetActive(workerIndex < workers.Length);
                if(workerIndex < workers.Length) {
                    string date = workers[workerIndex].LastEntrance.Replace('T', ' ');
                    icons[i].GetComponentInChildren<TMP_Text>(true).text = date;
                }
            }
            yield break;
        }
    }
}
