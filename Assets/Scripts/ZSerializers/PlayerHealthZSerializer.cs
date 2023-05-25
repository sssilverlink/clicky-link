[System.Serializable]
public sealed class PlayerHealthZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.Sprite fullHeart;
    public UnityEngine.Sprite heart3;
    public UnityEngine.Sprite heart2;
    public UnityEngine.Sprite heart1;
    public UnityEngine.Sprite emptyHeart;
    public System.Int32 health;
    public System.Int32 maxHealth;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PlayerHealthZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         fullHeart = (UnityEngine.Sprite)typeof(PlayerHealth).GetField("fullHeart").GetValue(instance);
         heart3 = (UnityEngine.Sprite)typeof(PlayerHealth).GetField("heart3").GetValue(instance);
         heart2 = (UnityEngine.Sprite)typeof(PlayerHealth).GetField("heart2").GetValue(instance);
         heart1 = (UnityEngine.Sprite)typeof(PlayerHealth).GetField("heart1").GetValue(instance);
         emptyHeart = (UnityEngine.Sprite)typeof(PlayerHealth).GetField("emptyHeart").GetValue(instance);
         health = (System.Int32)typeof(PlayerHealth).GetField("health").GetValue(instance);
         maxHealth = (System.Int32)typeof(PlayerHealth).GetField("maxHealth").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(PlayerHealth).GetField("fullHeart").SetValue(component, fullHeart);
         typeof(PlayerHealth).GetField("heart3").SetValue(component, heart3);
         typeof(PlayerHealth).GetField("heart2").SetValue(component, heart2);
         typeof(PlayerHealth).GetField("heart1").SetValue(component, heart1);
         typeof(PlayerHealth).GetField("emptyHeart").SetValue(component, emptyHeart);
         typeof(PlayerHealth).GetField("health").SetValue(component, health);
         typeof(PlayerHealth).GetField("maxHealth").SetValue(component, maxHealth);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}