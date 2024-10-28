using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blacklist : MonoBehaviour
{
    DataManager manager;
    [HideInInspector] public string AlienName, species;
    public bool isAllowedToEnter;
    bool bl1, bl2, bl3;

    public TextMeshPro data;
    // Start is called before the first frame update
    private void Awake()
    {
        manager = DataManager.Instance;
        print(manager);
    }
    void OnEnable()
    {
        
        Invoke(nameof(StartValues), 0.05f);
    }

    public void StartValues()
    {
        CheckForArrays();
        DisplayValues();
    }

    public void CheckForArrays()
    {
        if (!manager.hasBlacklist) return;

        bl1 = false;
        bl2 = false;
        bl3 = false;

        if (manager.Blacklist_Name_Only.Length > 0) bl1 = true;
        if (manager.Blacklist_Species_Only.Length > 0) bl2 = true;
        if (manager.Blacklist_Name_And_Species.Length > 0) bl3 = true;
    }

    public void UpdateValues()
    {
        if (bl1)
        {
            foreach(string check in manager.Blacklist_Name_Only)
            {
                if (check == AlienName)
                {
                    isAllowedToEnter = false;
                    return;
                }
            }
        }
        if (bl2)
        {
            foreach (string check in manager.Blacklist_Species_Only)
            {
                if (check == species)
                {
                    isAllowedToEnter = false;
                    return;
                }
            }
        }
        if (bl3)
        {
            bool isname, isspecies;
            
            foreach (string check in manager.Blacklist_Name_And_Species)
            {
                isname = false;
                isspecies = false;

                string[] splitname = check.Split('.');

                if (splitname[0] == AlienName)
                {
                    isname = false;
                }
                if (splitname[1] == species)
                {
                    isspecies = false;
                }

                if (!isname && !isspecies)
                {
                    isAllowedToEnter = false;
                    return;
                }
                else
                {
                    isAllowedToEnter = true;
                }
            }
        }
    }

    public void DisplayValues()
    {
        if(!manager.hasBlacklist)
        {
            data.text = "NO BLACKLISTED CUSTOMERS TODAY";
            return;
        }

        if (bl1)
        {
            data.text += "ABSOLUTELY NO ";
            foreach(string check in manager.Blacklist_Name_Only)
            {
                data.text += check + " ";
            }
        }
        if (bl2)
        {
            data.text += "<br> ABSOLUTELY NO ";
            foreach (string check in manager.Blacklist_Species_Only)
            {
                data.text += check + " ";
            }
        }
        if (bl3)
        {
            foreach (string check in manager.Blacklist_Name_And_Species)
            {
                string[] splitname = check.Split('.');
                data.text += "<br> ABSOLUTELY NO " + splitname[1] + " NAMED " + splitname[0];
            }
        }
    }

    public bool GetValue()
    {
        return isAllowedToEnter;
    }
}
