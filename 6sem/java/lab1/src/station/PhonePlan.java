package station;

public class PhonePlan extends PhoneEntity{
    private double _pricePerCallSecond;

    public PhonePlan() { }

    public PhonePlan(String name, String description, double pricePerCallSecond) {
        super(name, description);
        _pricePerCallSecond = pricePerCallSecond;
    }

    public double getPricePerCallSecond() {
        return _pricePerCallSecond;
    }

    public void setPricePerCallSecond(double pricePerCallSecond) {
        _pricePerCallSecond = pricePerCallSecond;
    }

    @Override
    public String toString() {
        return String.format("Тариф %s\n%s\nЦена за секунду разговора %f", getName(), getDescription(), getPricePerCallSecond());
    }
}
