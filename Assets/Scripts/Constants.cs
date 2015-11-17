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
        0.75f,
        0.65f,
        0.5f,
        0.25f,
        0.1f
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
        SPEED
    }

    public const float GLOBAL_BOOST_RATE = 100f;

    public static Dictionary<BOOST_TYPES, int> BOOSTS_RATES = new Dictionary<BOOST_TYPES, int>() {
        { BOOST_TYPES.FIRE_RATE, 10},
        { BOOST_TYPES.SPEED, 10}
    };

    public static int boostTotalWeight = 0;

    public enum WeaponTypes {
        SINGLE_SHOT,
        DOUBLE_SHOT,
        TRIPLE_SHOT,
        TRI_WAY,
        FIVE_WAY
    }
}
