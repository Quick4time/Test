using UnityEngine;
using UnityEngine.Purchasing;
using System.Collections;
using System.Collections.Generic;
using System;

// Implementation of Unity IAP
public class BerryStoreAssistant : MonoBehaviour, INeedLocalization {


    public List<ItemInfo> items = new List<ItemInfo>();
    public ItemInfo GetItemByID(string id) {
        return items.Find(x => x.id == id);
    }

    public List<IAP> iaps = new List<IAP>();
    public IAP GetIAPByID(string id) {
        return iaps.Find(x => x.id == id);
    }

	public static BerryStoreAssistant main;
	public Dictionary<string, string> marketItemPrices = new Dictionary<string, string>();

    Action iap_reward = delegate{};

	void Awake () {
		main = this;
        DebugPanel.AddDelegate("Add some seeds", () => {
            main.Purchase(0, "seed", 100);
        });
	}


    // Function item purchase
    public void Purchase(int seedsCount, string goodId, int goodCount) {
        if (ProfileAssistant.main.local_profile["seed"] < seedsCount) {
            UIAssistant.main.ShowPage("Store");
            return;
        }
        ProfileAssistant.main.local_profile["seed"] -= seedsCount;
        ProfileAssistant.main.local_profile[goodId] += goodCount;
        ProfileAssistant.main.SaveUserInventory();
        ItemCounter.RefreshAll();
        AudioAssistant.Shot("Buy");

    }

	// Function item purchase
	public void PurchaseIAP (string id, string goodId, int goodCount)
	{
        IAP iap = GetIAPByID(id);
        if (iap != null) {
            iap_reward = () => {Purchase(0, goodId, goodCount);};
            //BuyProductID(iap.id);
        }
    }


    public List<string> RequriedLocalizationKeys() {
        List<string> result = new List<string>();
        foreach (ItemInfo item in items) {
            result.Add("item_" + item.id + "_description");
            result.Add("item_" + item.id + "_name");
        }
        return result;
    }

    [System.Serializable]
    public class ItemInfo {
        public string name;
        public string id;
        public string localization_description { get { return "item_" + id + "_description"; } }
        public string localization_name { get { return "item_" + id + "_name"; } }
    }

    [System.Serializable]
    public class IAP {
        public string id;
        public string sku;
    }
}
