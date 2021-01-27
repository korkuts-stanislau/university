package users.requests;

public class PhoneChangeRequest extends Request{
    private final String _newPhoneNumber;

    public PhoneChangeRequest(String name, String description, String username, String newPhoneNumber) {
        super(name, description, username);
        _newPhoneNumber = newPhoneNumber;
    }

    public String getNewPhoneNumber() {
        return _newPhoneNumber;
    }
}
