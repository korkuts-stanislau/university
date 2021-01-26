package station;

public abstract class PhoneEntity {
    private String _name;
    private String _description;

    public PhoneEntity(String name, String description) {
        _name = name;
        _description = description;
    }

    public String getName() {
        return _name;
    }

    public String getDescription() {
        return _description;
    }
}
