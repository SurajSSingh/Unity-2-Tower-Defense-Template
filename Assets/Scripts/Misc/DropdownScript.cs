using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownScript : MonoBehaviour
{
    public TowerListScript listManager;
    private TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = this.GetComponent<TMP_Dropdown>();
        dropdown.options.Clear();
        foreach (TowerType tower in listManager.towerList)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(tower.towerName, tower.sprite));

        }
        dropdown.RefreshShownValue();
    }
}
