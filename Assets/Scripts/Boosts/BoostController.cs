using UnityEngine;
using System.Collections.Generic;

public class BoostController : MonoBehaviour {

    [SerializeField]
    private GameObject[] gameObjectBoosts;

    private Dictionary<Constants.BOOST_TYPES, GameObject> availableBoosts;
    private Dictionary<Constants.WEAPON_TYPES, GameObject> availableWeapons;

    void Start() {

        if (gameObjectBoosts != null && gameObjectBoosts.Length > 0) {
            availableBoosts = new Dictionary<Constants.BOOST_TYPES, GameObject>();
            availableWeapons = new Dictionary<Constants.WEAPON_TYPES, GameObject>();

            for (int i = 0; i < gameObjectBoosts.Length; ++i) {
                BaseBoost baseBoost = gameObjectBoosts[i].GetComponent<BaseBoost>();
                Constants.BOOST_TYPES type = baseBoost.GetBoostType();

                if (type == Constants.BOOST_TYPES.WEAPON) {
                    BaseWeaponBoost weaponBoost = baseBoost as BaseWeaponBoost;
                    availableWeapons.Add(weaponBoost.GetWeaponType(), gameObjectBoosts[i]); 
                } else {
                    availableBoosts.Add(baseBoost.GetBoostType(), gameObjectBoosts[i]);
                }
            }
        }
    }

    public void SpawnRandomBoost(Vector3 position) {
        float spawnRand = Random.Range(0, 100);

        if (spawnRand <= Constants.GLOBAL_BOOST_RATE) {
            Constants.BOOST_TYPES boostType = UtilFunctions.GetRandomBoostType();
            GameObject boost;
            
            if (boostType == Constants.BOOST_TYPES.WEAPON) {
                Constants.WEAPON_TYPES weaponType = UtilFunctions.GetRandomWeaponType();
                boost = availableWeapons[weaponType];
            } else {
                boost = availableBoosts[boostType];
            }

            //TODO use the same position the original object was
            Instantiate(boost, position, Quaternion.identity);
        }
    }
}
