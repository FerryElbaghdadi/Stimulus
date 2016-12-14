using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.ComponentModel;


/*
 * THIS SCRIPT REPLACES UNITY'S OWN NetworkManagerHUD.
 * We do this for the sake of custom buttons, more network abilities and more.
 * 
 * This script takes care of hosting, joining, and disconnecting of the server
 * by simply clicking one of the buttons.
 */


//#if ENABLE_UNET

namespace UnityEngine.Networking
{
    [AddComponentMenu("Network/CustomNetworkManagerHUD")] // We add a menu item for our CustomNetworkManagerHUD.
    [RequireComponent(typeof(NetworkManager))] // For this script to be added on an object, it needs to have the NetworkManager component.
    [EditorBrowsable(EditorBrowsableState.Never)] 

    

    public class CustomNetworkManagerHUD : MonoBehaviour
    {

        public delegate void ButtonEventHandler();
        public ButtonEventHandler OnClientConnect; // We will be needing this delegate to let other scripts know.
        public ButtonEventHandler OnClientDisconnect; // We will be needing this delegate to let other scripts know.

        [SerializeField] private NetworkManager _networkManager;  // We need to let the NetworkManager know what happens in here.
        [SerializeField] private InputField _networkAdressField; // An input field for our class code.

        private bool _noConnection; // Are we connected, or aren't we?

        private bool _runningHost; // We need to know whether the host is running.
        private bool _runningClient; // Or if the client has joined the host.


        void Awake()
        {
            _noConnection = (_networkManager.client == null || _networkManager.client.connection == null ||
                                 _networkManager.client.connection.connectionId == -1);

            /*
             * This boolean is to check whether Unity has no connection at all to the host.
             * This is to prevent any bugs.
             */
        }

        void Update()
        {
            if (_runningHost)
            HostGame();

            if (_runningClient)
                JoinGame();


            /*
             * Network components need to work in an update.
             * It needs to check per frame whether we are connected, or not.
             */
        }
        

        void HostGame()
        {
            if (!_networkManager.IsClientConnected() && !NetworkServer.active)
            {
                if (_noConnection)
                {
                    _networkManager.StartHost();
                }

                // If our client hasn't connected to the server, and the server isn't active...
                // And no connections have been made yet, start a host!
            }
        }

        void JoinGame()
        {
            if (!_networkManager.IsClientConnected() && !NetworkServer.active)
            {
                if (_noConnection)
                {
                    if (_networkAdressField.text == CodeStrings.stimulus)
                    _networkManager.networkAddress = CodeStrings.localhost;

                    
                    if (_networkManager.networkAddress != null)
                    _networkManager.StartClient();
                    else
                    Debug.LogError("NO ADDRESS SET");

                    /*
                     * If the user does not have a connection to a server yet, it can join the server.
                     * Just make sure to put in the class code, otherwise it won't work.
                     */
                }

          
                else
                {
                    if (OnClientConnect != null)
                        OnClientConnect();


                    // If the client connects, send out a signal!

                }
              
                _runningClient = false;

                // This is to prevent multiple clients to join on one computer.
            }
            
        }

        public void StopClient()
        {
            _networkManager.StopClient();
        }

        // Simply makes the client exit.

        public void HostGameButton()
        {
            _runningHost = true;
        }

        // This boolean turns true the moment the host button gets activated.

        public void JoinGameButton()
        {
            _runningClient = true;
        }

        // This boolean turns true the moment the join button has been activated.

    }
}
//#endif //ENABLE_UNET