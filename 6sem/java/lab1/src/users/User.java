package users;

public abstract class User {
    private final String _username;
    private final String _password;

    public User(String username, String password){
        _username = username;
        _password = password;
    }

    public String getUsername() {
        return _username;
    }

    public String getPassword() {
        return _password;
    }
}
