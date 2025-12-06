[System.Serializable]
public class TileData {
    public TileType type;
    public int growthStage;
    public bool hasCrop;
}

public enum TileType {
    Grass,
    Soil,
    // .....
}