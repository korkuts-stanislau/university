package users;

public abstract class User {
    private String _username;
    private String _password;

    public User() {

    }

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

    public void setUsername(String username) { _username = username; }

    public void setPassword(String password) { _password = password; }
}
