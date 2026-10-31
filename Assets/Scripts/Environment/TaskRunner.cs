using UnityEngine;

public class TaskRunner : MonoBehaviour {
    public static TaskRunner Instance { get; private set; }

    private void Awake() {
        Instance = this;
        
    }
}
