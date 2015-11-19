
public class SpeedUp : BaseBoost {

    protected override void Apply() {
        playerController.speed = UtilFunctions.GetNextRate(playerController.speed);
        playerController.UpdateSpeed();
    }

    public override Constants.BOOST_TYPES GetBoostType() {
        return Constants.BOOST_TYPES.SPEED;
    } 
}
