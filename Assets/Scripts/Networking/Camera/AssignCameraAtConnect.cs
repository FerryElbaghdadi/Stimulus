using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AssignCameraAtConnect : NetworkBehaviour {

	[SerializeField] private Camera _hostCamera;
    [SerializeField] private Camera _clientCamera;
    
    void Start()
    {

        CheckIsLocal();

        if (Network.isServer)
        {
            _clientCamera.gameObject.SetActive(false);
            _hostCamera.gameObject.SetActive(true);
        }
            
        else if (Network.isClient)
        {
            _hostCamera.gameObject.SetActive(false);
            _clientCamera.gameObject.SetActive(true);
        }
            
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
