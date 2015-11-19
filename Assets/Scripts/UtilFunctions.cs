﻿using UnityEngine;
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

    public static Constants.BOOST_TYPES GetRandomBoostType() {
        if (Constants.boostTotalWeight == 0) {
            foreach (int weight in Constants.BOOSTS_RATES.Values) {
                Constants.boostTotalWeight += weight;
            }
        }

        float rand = Random.Range(0, Constants.boostTotalWeight);
        float accumulate = 0;

        foreach (KeyValuePair<Constants.BOOST_TYPES, int> kv in Constants.BOOSTS_RATES) {
            accumulate += kv.Value;

            if (accumulate > rand) {
                return kv.Key;
            }
        }

        return Constants.BOOST_TYPES.SPEED;
    }
}