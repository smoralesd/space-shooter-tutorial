using UnityEngine;

public class FireRateUp: BasePowerUp {

    protected override void Apply() {
        playerController.fireRateType = Constants.GetNextFireRate(playerController.fireRateType);
        playerController.UpdateFireRate();
    }
}
