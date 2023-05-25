[System.Serializable]
public sealed class gameManagerScriptZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 money;
    public TMPro.TextMeshProUGUI moneyText;
    public TMPro.TextMeshProUGUI levelCounter;
    public TMPro.TextMeshProUGUI killCounter;
    public System.Int32 level;
    public System.Int32 levelRequirement;
    public System.Int32 killCount;
    public System.Int32 baseAttack;
    public System.Int32 attackMultiplier;
    public System.Int32 attackPower;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public gameManagerScriptZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         money = (System.Int32)typeof(gameManagerScript).GetField("money").GetValue(instance);
         moneyText = (TMPro.TextMeshProUGUI)typeof(gameManagerScript).GetField("moneyText").GetValue(instance);
         levelCounter = (TMPro.TextMeshProUGUI)typeof(gameManagerScript).GetField("levelCounter").GetValue(instance);
         killCounter = (TMPro.TextMeshProUGUI)typeof(gameManagerScript).GetField("killCounter").GetValue(instance);
         level = (System.Int32)typeof(gameManagerScript).GetField("level").GetValue(instance);
         levelRequirement = (System.Int32)typeof(gameManagerScript).GetField("levelRequirement").GetValue(instance);
         killCount = (System.Int32)typeof(gameManagerScript).GetField("killCount").GetValue(instance);
         baseAttack = (System.Int32)typeof(gameManagerScript).GetField("baseAttack").GetValue(instance);
         attackMultiplier = (System.Int32)typeof(gameManagerScript).GetField("attackMultiplier").GetValue(instance);
         attackPower = (System.Int32)typeof(gameManagerScript).GetField("attackPower").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(gameManagerScript).GetField("money").SetValue(component, money);
         typeof(gameManagerScript).GetField("moneyText").SetValue(component, moneyText);
         typeof(gameManagerScript).GetField("levelCounter").SetValue(component, levelCounter);
         typeof(gameManagerScript).GetField("killCounter").SetValue(component, killCounter);
         typeof(gameManagerScript).GetField("level").SetValue(component, level);
         typeof(gameManagerScript).GetField("levelRequirement").SetValue(component, levelRequirement);
         typeof(gameManagerScript).GetField("killCount").SetValue(component, killCount);
         typeof(gameManagerScript).GetField("baseAttack").SetValue(component, baseAttack);
         typeof(gameManagerScript).GetField("attackMultiplier").SetValue(component, attackMultiplier);
         typeof(gameManagerScript).GetField("attackPower").SetValue(component, attackPower);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}