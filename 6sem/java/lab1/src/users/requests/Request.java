package users.requests;

public abstract class Request {
    private final String _name;
    private final String _description;
    private final String _username;

    public Request(String name, String description, String username){
        _name = name;
        _description = description;
        _username = username;
    }

    public String getName() {
        return _name;
    }

    public String getDescription() {
        return _description;
    }

    public String getUsername() {
        return _username;
    }
}
