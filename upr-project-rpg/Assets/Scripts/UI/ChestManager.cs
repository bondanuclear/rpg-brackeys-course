using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    Transform target;
    UIManager uiManager;
    [SerializeField] float distanceToUnableChest = 5f;
    [SerializeField] bool isUsed = false;
    [SerializeField] private float speedOfOpening;
    [SerializeField] Transform chestUpperPart;
    // Start is called before the first frame update
    void Start()
    {
       uiManager = FindObjectOfType<UIManager>();
       target = PlayerManager.instance.player.transform;
    }
    // public void OpenChestModel()
    // {
    //     Vector3 rotationVector = new Vector3(-90,0,0);
    //     chestUpperPart.localRotation = Quaternion.Slerp(chestUpperPart.localRotation, Quaternion.Euler(rotationVector), Time.deltaTime * speedOfOpening);
    //     // to open the chest Quaternion.Euler(-90,0,0)
    //     // to close the chest Quaternion.Euler(0,0,0)
    // }
    IEnumerator RotateChestModel(Vector3 rotationVector)
    {
        Debug.Log("Starting to open the chest");
        float timePassed = 0f;
        //Vector3 rotationVector = new Vector3(-90, 0, 0);
        while(timePassed < 0.9f)
        {
            timePassed += Time.deltaTime;
            chestUpperPart.localRotation = Quaternion.Slerp(
                chestUpperPart.localRotation,
                 Quaternion.Euler(rotationVector),
                  timePassed/speedOfOpening);
                  //Debug.Log(timePassed);
                 
                  yield return new WaitForEndOfFrame();
        }
        
        yield return null;
        
    }
    IEnumerator ProcessOpenChest()
    {
        yield return RotateChestModel(new Vector3(-90, 0, 0));
        OpenUI();
        yield return null;
        isUsed = true;
    }
    IEnumerator ProcessCloseChest()
    {
        yield return RotateChestModel(new Vector3(0,0,0));
    }
    public void SetUsed(bool state)
    {
        // isUsed = state;
        //OpenUI();
        StartCoroutine(ProcessOpenChest());
        
    }
    void OpenUI()
    {
        uiManager.ProcessUI(true);
        uiManager.ProcessChestUI(true);
        //OpenChestModel();
    }
    void CloseUI()
    {
        uiManager.ProcessChestUI(false);
        uiManager.ProcessUI(false);
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(isUsed == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                UnableChest();
            }
            else if(distance > distanceToUnableChest)
            {
                UnableChest();
            }
        }
        
        
    }
        // if needed, make this method of type IEnumerator, so that we can't open chest until
        // it's fully closed
    private void UnableChest()
    {
        StartCoroutine(ProcessCloseChest());
        CloseUI();
        isUsed = false;
    }
}
