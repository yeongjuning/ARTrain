using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zappar;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] GameObject goTrainPrefab;
    [SerializeField] ZapparInstantTrackingTarget instantTracker;
    [SerializeField] Button btnStart;

    [SerializeField] Text txtIsPlaceTracker;

    public bool IsPlace { private set; get; }
    public bool IsStop { private set; get; }

    bool isInvoke = false;
    

    void Awake()
    {
        Instance = this;

        btnStart.interactable = false;
        goTrainPrefab.SetActive(false);
    }

    void Start()
    {
        IsPlace = false;
        Invoke("InvokeTrainActive", 1f);
    }

    void InvokeTrainActive()
    {
        isInvoke = true;
        goTrainPrefab.SetActive(true);
        btnStart.interactable = true;
    }

    void Update()
    {
        if (false == isInvoke) return;
        if (IsPlace) return;

        txtIsPlaceTracker.text = "<color=red>false</color>";
    }

    public void OnClickStartTrain()
    {
        instantTracker.PlaceTrackerAnchor();
        StartCoroutine(CoMoveTrain());
    }

    public void OnClickStopTrain()
    {
        var train = goTrainPrefab.GetComponent<Train>();
        train.velocity = 0f;

        IsStop = true;
    }

    IEnumerator CoMoveTrain()
    {
        yield return null;
        if (goTrainPrefab.activeSelf) IsPlace = true;
        txtIsPlaceTracker.text = "<color=red>true</color>";
    }
}
