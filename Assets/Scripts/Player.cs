using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CinemachineVirtualCamera fps, tps;
    public ThirdPersonController thirdPersonController;
    StarterAssetsInputs starterAssetsInputs;
    public GameObject freeViewCam, buildingCams;
    private void Awake()
    {
        starterAssetsInputs = thirdPersonController.GetComponent<StarterAssetsInputs>();
    }

    public void ActivatePlayer(bool enable = true)
    {
        InputHandler.Instance.isPlayerActive = enable;
        freeViewCam.gameObject.SetActive(!enable);
        buildingCams.gameObject.SetActive(!enable);
        thirdPersonController.gameObject.SetActive(enable);
        if (enable)
        {
            //StartCoroutine(LockCursor());
            if (InputHandler.Instance.IsTeleporting)
            {
                tps.gameObject.SetActive(enable);
                fps.gameObject.SetActive(!enable);
            }
            else
            {
                fps.gameObject.SetActive(enable);
                tps.gameObject.SetActive(!enable);
            }
        }
        else
        {
            fps.gameObject.SetActive(enable);
            tps.gameObject.SetActive(enable);
        }
    }
    public void ActivatePlayer(Transform spawnTransform, bool enable = true)
    {
        InputHandler.Instance.isPlayerActive = enable;
        freeViewCam.gameObject.SetActive(!enable);
        buildingCams.gameObject.SetActive(!enable);
        thirdPersonController.gameObject.SetActive(enable);

        if (enable)
        {
            thirdPersonController.transform.position = spawnTransform.position;
            thirdPersonController.transform.eulerAngles = spawnTransform.eulerAngles;
            //StartCoroutine(LockCursor());
            if (InputHandler.Instance.IsTeleporting)
            {
                tps.gameObject.SetActive(enable);
                fps.gameObject.SetActive(!enable);
            }
            else
            {
                fps.gameObject.SetActive(enable);
                tps.gameObject.SetActive(!enable);
            }
        }
        else
        {
            fps.gameObject.SetActive(enable);
            tps.gameObject.SetActive(enable);
        }
    }

    // public IEnumerator LockCursor()
    // {
    //     starterAssetsInputs.cursorLocked = false;
    //     yield return new WaitForSeconds(0.5f);
    //     starterAssetsInputs.cursorLocked = true;
    //     starterAssetsInputs.cursorInputForLook = false;
    //     yield return new WaitForSeconds(0.5f);
    //     starterAssetsInputs.cursorInputForLook = true;
    // }

}
