package users.requests;

public abstract class Request {
    private String _name;
    private String _description;
    private String _username;

    public Request() {}

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

    public void setName(String name) {
        _name = name;
    }

    public void setDescription(String description) {
        _description = description;
    }

    public void setUsername(String username) {
        _username = username;
    }
}
