using UnityEngine;
using System.Collections.Generic;

public class BoostController : MonoBehaviour {

    [SerializeField]
    private GameObject[] gameObjectBoosts;

    private Dictionary<Constants.BOOST_TYPES, GameObject> availableBoosts;

    void Start() {
        if (gameObjectBoosts != null && gameObjectBoosts.Length > 0) {
            availableBoosts = new Dictionary<Constants.BOOST_TYPES, GameObject>(gameObjectBoosts.Length);
            for (int i = 0; i < gameObjectBoosts.Length; ++i) {
                BaseBoost baseBoost = gameObjectBoosts[i].GetComponent<BaseBoost>();
                availableBoosts.Add(baseBoost.GetBoostType(), gameObjectBoosts[i]);
            }
        }
    }

    public void SpawnRandomBoost(Vector3 position) {
        float spawnRand = Random.Range(0, 100);

        if (spawnRand <= Constants.GLOBAL_BOOST_RATE) {
            Constants.BOOST_TYPES boostType = UtilFunctions.GetRandomBoostType();
            GameObject boost = availableBoosts[boostType];
            //TODO use the same position the original object was
            Instantiate(boost, position, Quaternion.identity);
        }
    }
}
