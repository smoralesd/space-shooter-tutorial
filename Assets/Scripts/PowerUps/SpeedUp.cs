using UnityEngine;
using System.Collections;

public class SpeedUp : BasePowerUp {

    protected override void Apply() {
        playerController.speed = UtilFunctions.GetNextRate(playerController.speed);
        playerController.UpdateSpeed();
    }
}
