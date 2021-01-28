package users.requests;

public abstract class Request {
    private String _username;

    public Request() {}

    public Request(String username){
        _username = username;
    }

    public String getUsername() {
        return _username;
    }

    public void setUsername(String username) {
        _username = username;
    }
}
