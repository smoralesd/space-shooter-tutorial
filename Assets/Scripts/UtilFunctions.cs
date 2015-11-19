using UnityEngine;
using System.Collections.Generic;

public class UtilFunctions {

    public static Constants.RATES GetNextRate(Constants.RATES current) {
        Constants.RATES result = current;
        switch (current) {
            case Constants.RATES.SLOWEST:
                result = Constants.RATES.SLOW;
                break;
            case Constants.RATES.SLOW:
                result = Constants.RATES.MEDIUM;
                break;
            case Constants.RATES.MEDIUM:
                result = Constants.RATES.FAST;
                break;
            case Constants.RATES.FAST:
                result = Constants.RATES.FASTEST;
                break;
        }

        return result;
    }

    public static float GetFireRateValue(Constants.RATES type) {
        return Constants.FIRE_RATES_VALUES[(int)type];
    }

    public static float GetSpeedValue(Constants.RATES type) {
        return Constants.SPEED_VALUES[(int)type];
    }

    private static int boostTotalWeight = 0;

    public static Constants.BOOST_TYPES GetRandomBoostType() {
        if (boostTotalWeight == 0) {
            foreach (int weight in Constants.BOOSTS_RATES.Values) {
                boostTotalWeight += weight;
            }
        }

        float rand = Random.Range(0, boostTotalWeight);
        float accumulate = 0;

        foreach (KeyValuePair<Constants.BOOST_TYPES, int> kv in Constants.BOOSTS_RATES) {
            accumulate += kv.Value;

            if (accumulate > rand) {
                return kv.Key;
            }
        }

        return Constants.BOOST_TYPES.SPEED;
    }

    private static int weaponTotalWeight = 0;

    public static Constants.WEAPON_TYPES GetRandomWeaponType() {
        if (weaponTotalWeight == 0) {
            foreach (int weight in Constants.WEAPON_RATES.Values) {
                weaponTotalWeight += weight;
            }
        }

        float rand = Random.Range(0, weaponTotalWeight);
        float accumulate = 0;

        foreach (KeyValuePair<Constants.WEAPON_TYPES, int> kv in Constants.WEAPON_RATES) {
            accumulate += kv.Value;

            if (accumulate > rand) {
                return kv.Key;
            }
        }

        return Constants.WEAPON_TYPES.DOUBLE_SHOT;
    }
}
