using System.Collections.Generic;

public static class Constants {

    public enum RATES {
        SLOWEST = 0,
        SLOW,
        MEDIUM,
        FAST,
        FASTEST
    };

    public static float[] FIRE_RATES_VALUES = new float [5] {
        0.7f,
        0.6f,
        0.5f,
        0.4f,
        0.2f
        };


    public static float[] SPEED_VALUES = new float[5] {
        4f,
        6f,
        8f,
        10f,
        12f 
    };


    public enum BOOST_TYPES {
        FIRE_RATE,
        SPEED,
        WEAPON
    }

    public const float GLOBAL_BOOST_RATE = 20f;

    public static Dictionary<BOOST_TYPES, int> BOOSTS_RATES = new Dictionary<BOOST_TYPES, int>() {
        { BOOST_TYPES.FIRE_RATE, 30},
        { BOOST_TYPES.SPEED, 50},
        { BOOST_TYPES.WEAPON, 20}
    };

    public enum WEAPON_TYPES {
        SINGLE_SHOT,
        DOUBLE_SHOT,
        TRIPLE_SHOT,
        TRI_WAY,
        FIVE_WAY
    }

    public static Dictionary<WEAPON_TYPES, int> WEAPON_RATES = new Dictionary<WEAPON_TYPES, int>() {
        { WEAPON_TYPES.DOUBLE_SHOT, 30},
        { WEAPON_TYPES.TRIPLE_SHOT, 10},
        { WEAPON_TYPES.TRI_WAY, 30},
        { WEAPON_TYPES.FIVE_WAY, 5}
    };
}
