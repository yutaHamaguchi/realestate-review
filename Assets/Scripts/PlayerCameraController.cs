using UnityEngine;
namespace StarterAssets
{
    public class PlayerCameraController : MonoBehaviour
    {
        // Start is called before the first frame update
        private StarterAssetsInputs _input;
        public GameObject tpCam;
        public GameObject fpCam;
        public GameObject playerArmature;
        void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
        }
        private void Update()
        {
            if (_input.tp)
            {
                playerArmature.SetActive(true);
                tpCam.SetActive(true);
                fpCam.SetActive(false);
            }
            else
            {
                playerArmature.SetActive(false);
                tpCam.SetActive(false);
                fpCam.SetActive(true);
            }
        }
    }
}
