using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace PGGE.Multiplayer
{
    public class ConnectionController : MonoBehaviourPunCallbacks
    {
        private const string RoomName = "TestRoom"; // specific room name
        public GameObject mConnectionProgress;
        public GameObject mBtnJoinRoom;
        public GameObject mInputPlayerName;
        bool isConnecting = false;

        void Awake()
        {
            // this make sure we can use PhotonNetwork.LoadLevel() on
            // the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void Start()
        {
            // connect to photon master server
            mConnectionProgress.SetActive(false);
        }

        public void Connect()
        {
            mBtnJoinRoom.SetActive(false);
            mInputPlayerName.SetActive(false);
            mConnectionProgress.SetActive(true);

            if (PhotonNetwork.IsConnectedAndReady)
            {
                Debug.Log("Attempting to join or create the room...");
                PhotonNetwork.JoinOrCreateRoom(RoomName, new RoomOptions{MaxPlayers = 4}, TypedLobby.Default);
            } else
            {
                isConnecting = PhotonNetwork.ConnectUsingSettings();
                Debug.Log("Not connected to Master Server yet. Please wait...");
            }
        }

        public override void OnConnectedToMaster()
        {
            // once connected to master server, log this and allow room creation / joining
            Debug.Log("Connected to Master Server");
            if (isConnecting)
            {
                Debug.Log("OnConnectedToMaster() was called by PUN");
                PhotonNetwork.JoinOrCreateRoom(RoomName, new RoomOptions{MaxPlayers = 4}, TypedLobby.Default);
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
            isConnecting = false;
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError($"Failed to join room: {message}");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.LogError($"Failed to create room: {message}");
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("MultiplayerMap00");
        }
    }
}

