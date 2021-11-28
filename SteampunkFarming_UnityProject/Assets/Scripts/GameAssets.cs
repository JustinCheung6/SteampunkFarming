using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour 
{

    private static GameAssets _i;

    public static GameAssets i {
        get {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public Sprite s_ArmorNone;
    public Sprite s_Armor_1;
    public Sprite s_Armor_2;
}