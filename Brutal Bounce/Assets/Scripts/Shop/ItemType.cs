
public static class ItemUsefulTools
{
    public enum ItemType
    {
        Ball,
        Player,
        Trail
    }

    public static ItemType GetItemType(string typeString)
    {
        switch (typeString)
        {
            case "Ball":
                {
                    return ItemType.Ball;
                }
            case "Trail":
                {
                    return ItemType.Trail;
                }
            case "Player":
                {
                    return ItemType.Player;
                }
            default: return 0;
        }
    }

    public const string TrailString = "Trail";
    public const string BallString = "Ball";

    public const string TrailSkinIdString = "TrailSkinId";
    public const string BallSkinIdString = "BallSkinId";
}
