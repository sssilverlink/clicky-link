[System.Serializable]
public sealed class PlayerHealthBarZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.GameObject heartPrefab;
    public Player player;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PlayerHealthBarZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         heartPrefab = (UnityEngine.GameObject)typeof(PlayerHealthBar).GetField("heartPrefab").GetValue(instance);
         player = (Player)typeof(PlayerHealthBar).GetField("player").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(PlayerHealthBar).GetField("heartPrefab").SetValue(component, heartPrefab);
         typeof(PlayerHealthBar).GetField("player").SetValue(component, player);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}