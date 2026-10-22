using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [Header("Player")]
        [SerializeField] private GameObject character;
        private PlayerMovement player;
        private bool playerMovementWasEnabled;
        private bool inside;
        private bool usingComputer;

        [Header("Task queue")]
        public ComputerTaskQueue ComputerTask;

        [Header("Turning ON")]
        [SerializeField] private TextMeshProUGUI logging;
        [SerializeField] private GameObject loading;

        [Header("Login")]
        [SerializeField] private GameObject LoginState;
        [SerializeField] private TMP_InputField password;
        [SerializeField] private TextMeshProUGUI PlaceHolder;
        [SerializeField] private TMP_Text enterButtonLabel;

        [Header("Desktop")]
        [SerializeField] private GameObject Deskop;

        [Header("Pirated Games")]
        [SerializeField] private GameObject PiratedGames;

        [Header("Workers Logs")]
        [SerializeField] private GameObject Worklogs;

        [Header("Workers Logs UI")]
        [SerializeField] private GameObject[] workloggerObjects = new GameObject[9];

        public bool LoggedIn { get; set; }
        public bool LoginRequested { get; set; }

        //Easy names :D
        public TextMeshProUGUI LoadingLabel => logging;
        public GameObject LoadingScreen => loading;
        public GameObject LoginScreen => LoginState;
        public TMP_InputField PasswordInput => password;
        public TextMeshProUGUI LoginPlaceholder => PlaceHolder;
        public GameObject DesktopScreen => Deskop;
        public GameObject PiratedGamesScreen => PiratedGames;
        public GameObject WorklogsScreen => Worklogs;
        public GameObject[] WorklogIcons => workloggerObjects;

        private void Start() {
            if(character != null)
                player = character.GetComponentInParent<PlayerMovement>();

            Cameras.comand.CamChange(0);
            ComputerTask.EnqueueInitializationTasks(this);
        }

        private void Update() {
            if(Keyboard.current == null) return;

            if(Keyboard.current.eKey.wasPressedThisFrame && inside && !usingComputer) {
                Cameras.comand.CamChange(1);
                usingComputer = true;
                SetPlayerMovement(false);
                ComputerTask.EnqueueStartupTasks(this);
            }
            else if(Keyboard.current.escapeKey.wasPressedThisFrame && usingComputer) {
                CancelQueue();
                Cameras.comand.CamChange(0);
                usingComputer = false;
                SetPlayerMovement(true);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if(other.CompareTag("Player")) inside = true;
        }

        private void OnTriggerExit(Collider other) {
            if(other.CompareTag("Player")) inside = false;
        }

        private void SetPlayerMovement(bool enabled) {
            if(player == null) return;
            if(!enabled) {
                playerMovementWasEnabled = player.enabled;
                player.SetMovementEnabled(false);
            }
            else {
                player.SetMovementEnabled(playerMovementWasEnabled);
            }
        }

        private void OnDisable() {
            if(usingComputer)
            SetPlayerMovement(true);
            CancelQueue();
        }

        private void CancelQueue() {
            ComputerTask.CancelQueue();
        }

        public void OnInteract() {
            Debug.Log("Just logged");
        }


        public void Enter() {
            if(!LoggedIn) {
                LoginRequested = true;
                return;
            }

            ComputerTask.EnqueuePlayVSGameTask(this);
        }

        public void PlayVSGame() {
            ComputerTask.EnqueuePlayVSGameTask(this);
        }

        public void Pirated() {
            ComputerTask.EnqueuePiratedGamesTask(this);
        }

        public void Worklog() {
            ComputerTask.EnqueueOpenWorklogsTask(this);
        }

        public void ReturnDeskop() {
            ComputerTask.EnqueueReturnToDesktopTask(this);
        }
    }
}
