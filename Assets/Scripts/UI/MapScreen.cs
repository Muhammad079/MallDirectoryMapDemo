using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScreen : AppScreem
{
    public GameObject ShopName_Prefab;
    public Transform Content;
    public TMPro.TMP_InputField SearchBar;
    public List<GameObject> UIPrefabs = new List<GameObject>();
    public void InitializeUI(List<ShopData> shopDatas)
    {

        foreach (var item in shopDatas)
        {
            GameObject shopUI = Instantiate(ShopName_Prefab, Content);
            shopUI.GetComponentInChildren<TMPro.TMP_Text>().text = item.ShopInfo.ShopName;

            shopUI.GetComponent<Button>().onClick.AddListener(() =>
            {
                ApplicationManager.Instance.SetAgentDestination(item.ShopInfo.ShopPosition);
            });
            UIPrefabs.Add(shopUI);
        }

        SearchBar.onValueChanged.AddListener((x) =>
        {
            FilterSearch(x, UIPrefabs );
        });
    }
    void FilterSearch(string Keyword, List<GameObject> UIPrefabs)
    { 
        Keyword = Keyword.ToLower();

        foreach (var shop in UIPrefabs)
        {
            TMPro.TMP_Text buttonText = shop.GetComponentInChildren<TMPro.TMP_Text>();
            if (buttonText != null && buttonText.text.ToLower().Contains(Keyword))
            {
                shop.SetActive(true);
            }
            else
            {
                shop.SetActive(false);
            }
        }
    }
}
