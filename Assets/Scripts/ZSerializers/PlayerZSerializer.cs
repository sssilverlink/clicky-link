[System.Serializable]
public sealed class PlayerZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 currentHP;
    public System.Int32 maxHP;
    public System.String playerName;
    public TMPro.TextMeshProUGUI playerNameTextBox;
    public TMPro.TextMeshProUGUI playerCurrentHPTextBox;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PlayerZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         currentHP = (System.Int32)typeof(Player).GetField("currentHP").GetValue(instance);
         maxHP = (System.Int32)typeof(Player).GetField("maxHP").GetValue(instance);
         playerName = (System.String)typeof(Player).GetField("playerName").GetValue(instance);
         playerNameTextBox = (TMPro.TextMeshProUGUI)typeof(Player).GetField("playerNameTextBox").GetValue(instance);
         playerCurrentHPTextBox = (TMPro.TextMeshProUGUI)typeof(Player).GetField("playerCurrentHPTextBox").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Player).GetField("currentHP").SetValue(component, currentHP);
         typeof(Player).GetField("maxHP").SetValue(component, maxHP);
         typeof(Player).GetField("playerName").SetValue(component, playerName);
         typeof(Player).GetField("playerNameTextBox").SetValue(component, playerNameTextBox);
         typeof(Player).GetField("playerCurrentHPTextBox").SetValue(component, playerCurrentHPTextBox);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}