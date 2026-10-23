using System.Collections;
using TMPro;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Show Worker Data Task", menuName = "Tasks/Computer/Show Worker Data")]
    public sealed class ShowWorkerDataTask : Task {
        public override IEnumerator Execute(Computer computer) {
            int iconIndex = computer.ComputerTask.DequeueWorkerIconIndex();
            int workerIndex = ChangeWorklogPageTask.CurrentPage * computer.WorklogIcons.Length + iconIndex;
            Worker worker = computer.Workers[workerIndex];

            computer.DataCanvas.transform.Find("Name").GetComponent<TMP_Text>().text = $"Name: {worker.Name}";
            computer.DataCanvas.transform.Find("ID").GetComponent<TMP_Text>().text = $"ID: {worker.ID}";
            computer.DataCanvas.transform.Find("Clearance").GetComponent<TMP_Text>().text = $"Clearance: {worker.Clearance}";
            computer.DataCanvas.transform.Find("Entrance").GetComponent<TMP_Text>().text = $"Entrance: {worker.LastEntrance.Replace('T', ' ')}";
            computer.DataCanvas.transform.Find("Exit").GetComponent<TMP_Text>().text = $"Exit: {worker.LastExit.Replace('T', ' ')}";

            computer.WorklogsScreen.SetActive(false);
            computer.DataCanvas.SetActive(true);
            Cameras.comand.CamChange(2);
            yield break;
        }
    }
}
