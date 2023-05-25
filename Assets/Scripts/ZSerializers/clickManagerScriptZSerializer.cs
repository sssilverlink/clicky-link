[System.Serializable]
public sealed class clickManagerScriptZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Collections.Generic.List<System.Single> attackFairy;
    public System.Int32 attackFairyPrice;
    public System.Int32 attackFairyPower;
    public TMPro.TextMeshProUGUI attackFairyQtyText;
    public TMPro.TextMeshProUGUI attackFairyLabel;
    public System.Int32 swordUpgradePrice;
    public System.Int32 swordUpgradeCount;
    public TMPro.TextMeshProUGUI swordUpgradeQtyText;
    public TMPro.TextMeshProUGUI swordUpgradeLabel;
    public System.Int32 tForcePwrUpgradePrice;
    public System.Int32 tForcePowerUpgradeCount;
    public TMPro.TextMeshProUGUI tForcePowerQtyText;
    public TMPro.TextMeshProUGUI tForcePowerLabel;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public clickManagerScriptZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         attackFairy = (System.Collections.Generic.List<System.Single>)typeof(clickManagerScript).GetField("attackFairy").GetValue(instance);
         attackFairyPrice = (System.Int32)typeof(clickManagerScript).GetField("attackFairyPrice").GetValue(instance);
         attackFairyPower = (System.Int32)typeof(clickManagerScript).GetField("attackFairyPower").GetValue(instance);
         attackFairyQtyText = (TMPro.TextMeshProUGUI)typeof(clickManagerScript).GetField("attackFairyQtyText").GetValue(instance);
         attackFairyLabel = (TMPro.TextMeshProUGUI)typeof(clickManagerScript).GetField("attackFairyLabel").GetValue(instance);
         swordUpgradePrice = (System.Int32)typeof(clickManagerScript).GetField("swordUpgradePrice").GetValue(instance);
         swordUpgradeCount = (System.Int32)typeof(clickManagerScript).GetField("swordUpgradeCount").GetValue(instance);
         swordUpgradeQtyText = (TMPro.TextMeshProUGUI)typeof(clickManagerScript).GetField("swordUpgradeQtyText").GetValue(instance);
         swordUpgradeLabel = (TMPro.TextMeshProUGUI)typeof(clickManagerScript).GetField("swordUpgradeLabel").GetValue(instance);
         tForcePwrUpgradePrice = (System.Int32)typeof(clickManagerScript).GetField("tForcePwrUpgradePrice").GetValue(instance);
         tForcePowerUpgradeCount = (System.Int32)typeof(clickManagerScript).GetField("tForcePowerUpgradeCount").GetValue(instance);
         tForcePowerQtyText = (TMPro.TextMeshProUGUI)typeof(clickManagerScript).GetField("tForcePowerQtyText").GetValue(instance);
         tForcePowerLabel = (TMPro.TextMeshProUGUI)typeof(clickManagerScript).GetField("tForcePowerLabel").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(clickManagerScript).GetField("attackFairy").SetValue(component, attackFairy);
         typeof(clickManagerScript).GetField("attackFairyPrice").SetValue(component, attackFairyPrice);
         typeof(clickManagerScript).GetField("attackFairyPower").SetValue(component, attackFairyPower);
         typeof(clickManagerScript).GetField("attackFairyQtyText").SetValue(component, attackFairyQtyText);
         typeof(clickManagerScript).GetField("attackFairyLabel").SetValue(component, attackFairyLabel);
         typeof(clickManagerScript).GetField("swordUpgradePrice").SetValue(component, swordUpgradePrice);
         typeof(clickManagerScript).GetField("swordUpgradeCount").SetValue(component, swordUpgradeCount);
         typeof(clickManagerScript).GetField("swordUpgradeQtyText").SetValue(component, swordUpgradeQtyText);
         typeof(clickManagerScript).GetField("swordUpgradeLabel").SetValue(component, swordUpgradeLabel);
         typeof(clickManagerScript).GetField("tForcePwrUpgradePrice").SetValue(component, tForcePwrUpgradePrice);
         typeof(clickManagerScript).GetField("tForcePowerUpgradeCount").SetValue(component, tForcePowerUpgradeCount);
         typeof(clickManagerScript).GetField("tForcePowerQtyText").SetValue(component, tForcePowerQtyText);
         typeof(clickManagerScript).GetField("tForcePowerLabel").SetValue(component, tForcePowerLabel);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}