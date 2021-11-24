public class Car: IUpgradableCar
{
    public float Speed { get; set; }

    public Car(float speed)
    {
        Speed = speed;
    }
}

