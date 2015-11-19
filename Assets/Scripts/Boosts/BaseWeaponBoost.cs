
public abstract class BaseWeaponBoost : BaseBoost {

    protected override void Apply() {
        playerController.SetWeaponType(GetWeaponType());
    }

    public override Constants.BOOST_TYPES GetBoostType() {
        return Constants.BOOST_TYPES.WEAPON;
    }

    public abstract Constants.WEAPON_TYPES GetWeaponType();
}
