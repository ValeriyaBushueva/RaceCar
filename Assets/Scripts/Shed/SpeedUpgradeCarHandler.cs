
public class SpeedUpgradeCarHandler :IUpgradeHandler
{
    private float _speed;

    public SpeedUpgradeCarHandler(float speed)
    {
        _speed = speed;
    }

    public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
    {
        upgradableCar.Speed = _speed;
        return upgradableCar;
    }
}
