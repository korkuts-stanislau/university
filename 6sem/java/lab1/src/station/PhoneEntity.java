package station;

public abstract class PhoneEntity {
    private String _name;
    private String _description;

    public PhoneEntity() {}

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

    public void setName(String name) {
        _name = name;
    }

    public void setDescription(String description) {
        _description = description;
    }
}
