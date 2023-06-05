[System.Serializable]
public sealed class clickManagerScriptZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Collections.Generic.List<System.Single> attackFairy;
    public System.Int32 attackFairyPrice;
    public System.Int32 attackFairyPower;
    public System.Int32 swordUpgradePrice;
    public System.Int32 swordUpgradeCount;
    public System.Int32 tForcePwrUpgradePrice;
    public System.Int32 tForcePowerUpgradeCount;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public clickManagerScriptZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         attackFairy = (System.Collections.Generic.List<System.Single>)typeof(clickManagerScript).GetField("attackFairy").GetValue(instance);
         attackFairyPrice = (System.Int32)typeof(clickManagerScript).GetField("attackFairyPrice").GetValue(instance);
         attackFairyPower = (System.Int32)typeof(clickManagerScript).GetField("attackFairyPower").GetValue(instance);
         swordUpgradePrice = (System.Int32)typeof(clickManagerScript).GetField("swordUpgradePrice").GetValue(instance);
         swordUpgradeCount = (System.Int32)typeof(clickManagerScript).GetField("swordUpgradeCount").GetValue(instance);
         tForcePwrUpgradePrice = (System.Int32)typeof(clickManagerScript).GetField("tForcePwrUpgradePrice").GetValue(instance);
         tForcePowerUpgradeCount = (System.Int32)typeof(clickManagerScript).GetField("tForcePowerUpgradeCount").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(clickManagerScript).GetField("attackFairy").SetValue(component, attackFairy);
         typeof(clickManagerScript).GetField("attackFairyPrice").SetValue(component, attackFairyPrice);
         typeof(clickManagerScript).GetField("attackFairyPower").SetValue(component, attackFairyPower);
         typeof(clickManagerScript).GetField("swordUpgradePrice").SetValue(component, swordUpgradePrice);
         typeof(clickManagerScript).GetField("swordUpgradeCount").SetValue(component, swordUpgradeCount);
         typeof(clickManagerScript).GetField("tForcePwrUpgradePrice").SetValue(component, tForcePwrUpgradePrice);
         typeof(clickManagerScript).GetField("tForcePowerUpgradeCount").SetValue(component, tForcePowerUpgradeCount);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}