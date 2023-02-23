using UnityEngine;
static class Borders
{
    static Vector3 MinBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -10f));
    static Vector3 MaxBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, -10f));
    public static Vector3 MinPos = new Vector3(MinBorder.x + 0.5f, MinBorder.y + 0.5f, MinBorder.z);
    public static Vector3 MaxPos = new Vector3(MaxBorder.x - 0.5f, MaxBorder.y - 0.5f, MaxBorder.z);
    public static Vector2 GetRandomVectorInViewport()
    {
        return new Vector2(Random.Range(MinPos.x, MaxPos.x), Random.Range(MinPos.y, MaxPos.y));
    }
}