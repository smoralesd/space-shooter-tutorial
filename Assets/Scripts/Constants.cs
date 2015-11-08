﻿
public static class Constants {

    public enum FIRE_RATES {
        FIRE_RATE_SLOWEST = 0,
        FIRE_RATE_SLOW,
        FIRE_RATE_MEDIUM,
        FIRE_RATE_FAST,
        FIRE_RATE_FASTEST
    };

    private static float[] FIRE_RATES_VALUES = new float [5] {
        0.75f,
        0.65f,
        0.5f,
        0.25f,
        0.1f
        };

    public static float FireRate(FIRE_RATES type) {
        return FIRE_RATES_VALUES[(int)type];
    } 
}