package station;

public class PhoneService extends PhoneEntity {
    private double _price;

    public PhoneService() {}

    public PhoneService(String name, String description, double price) {
        super(name, description);
        _price = price;
    }

    public double getPrice() {
        return _price;
    }

    public void setPrice(double price) { _price = price; }
}
