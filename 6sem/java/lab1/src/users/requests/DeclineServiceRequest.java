package users.requests;

import station.PhoneService;

public class DeclineServiceRequest extends Request{
    private PhoneService _phoneServiceToRemove;

    public DeclineServiceRequest() {}

    public DeclineServiceRequest(String username, PhoneService phoneServiceToRemove) {
        super(username);
        _phoneServiceToRemove = phoneServiceToRemove;
    }

    public PhoneService getPhoneServiceToRemove() {
        return _phoneServiceToRemove;
    }

    public void setPhoneServiceToRemove(PhoneService phoneServiceToRemove) {
        _phoneServiceToRemove = phoneServiceToRemove;
    }

    @Override
    public String toString() {
        return String.format("Запрос пользователя %s на удаление услуги %s", getUsername(), _phoneServiceToRemove);
    }
}
