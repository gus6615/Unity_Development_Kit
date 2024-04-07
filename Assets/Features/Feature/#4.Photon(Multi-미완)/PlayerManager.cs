using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Com.MyCompany.MyGame
{
    public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
    {
        public static GameObject LocalPlayerInstance;

        [SerializeField]
        private GameObject beams;

        [SerializeField]
        private float Health = 1f;

        bool IsFiring;

        private void Awake()
        {
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }

            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();
            if (_cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    _cameraWork.OnStartFollowing();
                }
            }
            beams.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                ProcessInputs();
                if (Health <= 0f)
                    MultiManager.Instance.LeaveRoom();

                if (IsFiring != beams.activeInHierarchy)
                {
                    beams.SetActive(IsFiring);
                }
            }
        }

        private void ProcessInputs()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!IsFiring)
                {
                    IsFiring = true;
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                if (IsFiring)
                {
                    IsFiring = false;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!photonView.IsMine)
                return;

            if (!other.name.Contains("Beam"))
                return;

            Health -= 0.1f;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!photonView.IsMine)
                return;

            if (!other.name.Contains("Beam"))
                return;

            Health -= 0.1f * Time.deltaTime;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(IsFiring);
                stream.SendNext(Health);
            }
            else
            {
                this.IsFiring = (bool)stream.ReceiveNext();
                this.Health = (float)stream.ReceiveNext();
            }
        }
    }
}