package station;

public class PhonePlan extends PhoneEntity{
    private double _price;

    public PhonePlan(String name, String description, double pricePerCallSecond) {
        super(name, description);
        _price = pricePerCallSecond;
    }

    public double getPricePerCallSecond() {
        return _price;
    }
}
