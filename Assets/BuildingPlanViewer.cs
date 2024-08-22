using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlanViewer : MonoBehaviour
{
    public int floors = 1;
    public List<Sprite> floorPlansSprites;
    public List<Transform> visitPoint;
    public Image floorViewImage;
    public Button floorViewBtn;
    public Button backBtn, visit;

    public static CinemachineVirtualCamera activeCam;

    public CinemachineVirtualCamera cinemachineVirtualCamera;

    public GameObject floorPlanPanel, floorPlanBtnPanel;

    private void Start()
    {
        floorViewBtn.onClick.AddListener(OnFloorViewClicked);
        backBtn.onClick.AddListener(OnBackPress);
        visit.onClick.AddListener(OnClickVisit);
    }

    public void SetFloorImage(int floorId)
    {
        floorViewImage.sprite = floorPlansSprites[floorId];
    }

    void OnFloorViewClicked()
    {
        floorPlanPanel.SetActive(true);
        floorPlanBtnPanel.SetActive(true);
        backBtn.gameObject.SetActive(true);
        visit.gameObject.SetActive(true);
        floorViewBtn.gameObject.SetActive(false);
        activeCam = cinemachineVirtualCamera;
        activeCam.gameObject.SetActive(true);
    }

    void OnBackPress()
    {
        floorPlanPanel.SetActive(false);
        floorPlanBtnPanel.SetActive(false);
        backBtn.gameObject.SetActive(false);
        visit.gameObject.SetActive(false);
        floorViewBtn.gameObject.SetActive(true);
        activeCam = cinemachineVirtualCamera;
        activeCam.gameObject.SetActive(false);
    }

    void OnClickVisit()
    {

    }

}
