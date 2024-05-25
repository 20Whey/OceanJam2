using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreInformation : MonoBehaviour
{
    public Upgrade upgrade;

    public TextMeshProUGUI Title, Desc;

    public ShowLevelUp showLevelUp;

    public UpgradeManager playerStats; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReapplyData()
    {
        Debug.Log(upgrade.upgradeName + " from: " + this.gameObject.name);

        Title.text = upgrade.upgradeName;
        Desc.text = upgrade.description;
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked: " + this.gameObject.name);

        Time.timeScale = 1.0f;

        showLevelUp.hideLevel();
        Debug.Log(Time.timeScale);
        playerStats.UpdatePlayerStats(upgrade);
    }
}
