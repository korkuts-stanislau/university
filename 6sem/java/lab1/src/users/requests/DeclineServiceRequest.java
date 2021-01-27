package users.requests;

import station.PhoneService;

public class DeclineServiceRequest extends Request{
    private final PhoneService _phoneServiceToRemove;

    public DeclineServiceRequest(String name, String description, String username, PhoneService phoneServiceToRemove) {
        super(name, description, username);
        _phoneServiceToRemove = phoneServiceToRemove;
    }

    public PhoneService getPhoneServiceToRemove() {
        return _phoneServiceToRemove;
    }
}
