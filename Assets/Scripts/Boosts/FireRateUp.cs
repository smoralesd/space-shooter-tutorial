using UnityEngine;

public class FireRateUp: BaseBoost {

    protected override void Apply() {
        playerController.fireRate = UtilFunctions.GetNextRate(playerController.fireRate);
        playerController.UpdateFireRate();
    }

    public override Constants.BOOST_TYPES GetBoostType() {
        return Constants.BOOST_TYPES.FIRE_RATE;
    } 
}
