using UnityEngine;

public class CamCore : MonoBehaviour {
    public static CamCore Instance { get; private set; }
    [SerializeField] private Camera[] cameras;
    private int cameraIndex = 0;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        EnableCamera(cameraIndex);
    }

    public void SwitchCamera() {
        cameraIndex = (cameraIndex + 1) % cameras.Length;
        EnableCamera(cameraIndex);
    }

    public void SwitchToCamera(int index) {
        cameraIndex = index;
        EnableCamera(cameraIndex);
    }

    private void EnableCamera(int activeIndex) {
        for(int i = 0; i < cameras.Length; i++) {
            if(cameras[i] != null) {
                cameras[i].gameObject.SetActive(i == activeIndex);
            }
        }
    }
}
