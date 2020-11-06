using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text tooltipText;
    // Start is called before the first frame update
    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        tooltipText.gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item){
        string tooltip = string.Format("<b>{0}</b>\n{1}\n",item.title,item.description);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }
}
