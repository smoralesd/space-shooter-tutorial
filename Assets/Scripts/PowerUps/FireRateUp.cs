using UnityEngine;

public class FireRateUp: BasePowerUp {

    protected override void Apply() {
        playerController.fireRate = UtilFunctions.GetNextRate(playerController.fireRate);
        playerController.UpdateFireRate();
    }
}
