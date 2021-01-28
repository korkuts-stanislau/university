package users.requests;

public class PhoneChangeRequest extends Request{
    private String _newPhoneNumber;

    public PhoneChangeRequest() {

    }

    public PhoneChangeRequest(String username, String newPhoneNumber) {
        super(username);
        _newPhoneNumber = newPhoneNumber;
    }

    public String getNewPhoneNumber() {
        return _newPhoneNumber;
    }

    public void setNewPhoneNumber(String newPhoneNumber) { _newPhoneNumber = newPhoneNumber; }

    @Override
    public String toString() {
        return String.format("Запрос пользователя %s на новый номер %s", getUsername(), _newPhoneNumber);
    }
}
