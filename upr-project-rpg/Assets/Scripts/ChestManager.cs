using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    Transform target;
    UIManager uiManager;
    [SerializeField] float distanceToUnableChest = 5f;
    bool isUsed = false;
    // Start is called before the first frame update
    void Start()
    {
       uiManager = FindObjectOfType<UIManager>();
        target = PlayerManager.instance.player.transform;
    }
    public void SetUsed(bool state)
    {
        isUsed = state;
        OpenUI();
    }
    void OpenUI()
    {
        uiManager.ProcessUI(true);
        uiManager.ProcessChestUI(true);
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

    private void UnableChest()
    {
        CloseUI();
        isUsed = false;
    }
}
