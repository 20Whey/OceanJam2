using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowLevelUp : MonoBehaviour
{
    public GameObject levelUpObject;

    public GameObject Upgrade1, Upgrade2, Upgrade3;

    public Text UpgradeName, UpgradeDesc;

    public UpgradeManager UpgradeManager;

    private TextMeshProUGUI textMeshProComponent; // Reference to the TextMeshPro component

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshLevelUp()
    {
        ShowUpgrade();
    }

    public void ShowUpgrade()
    {
        levelUpObject.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log(Time.timeScale);

        Upgrade temp1 = UpgradeManager.GetRandomUpgrade();
        Upgrade temp2 = UpgradeManager.GetRandomUpgrade();
        Upgrade temp3 = UpgradeManager.GetRandomUpgrade();


        StoreInformation temp01 = Upgrade1.gameObject.GetComponent<StoreInformation>();
        StoreInformation temp02 = Upgrade2.gameObject.GetComponent<StoreInformation>();
        StoreInformation temp03 = Upgrade3.gameObject.GetComponent<StoreInformation>();

        temp01.upgrade = temp1;
        temp02.upgrade = temp2;
        temp03.upgrade = temp3;

        Upgrade1.gameObject.GetComponent<StoreInformation>().ReapplyData();
        Upgrade2.gameObject.GetComponent<StoreInformation>().ReapplyData();
        Upgrade3.gameObject.GetComponent<StoreInformation>().ReapplyData();

    }

    public void hideLevel()
    {
        levelUpObject.SetActive(false);

    }
}
