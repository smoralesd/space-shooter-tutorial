
public class FireRateUp: BaseBoost {

    protected override void Apply() {
        playerController.FireRateUp();
    }

    public override Constants.BOOST_TYPES GetBoostType() {
        return Constants.BOOST_TYPES.FIRE_RATE;
    } 
}
