package users.requests;

public abstract class Request {
    private final String _name;
    private final String _description;

    public Request(String name, String description){
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
