package users.requests;

import station.PhoneService;

public class DeclineServiceRequest extends Request{
    private final PhoneService _phoneServiceToRemove;

    public DeclineServiceRequest(String name, String description, PhoneService phoneServiceToRemove) {
        super(name, description);
        _phoneServiceToRemove = phoneServiceToRemove;
    }

    public PhoneService getNewPhonePlan() {
        return _phoneServiceToRemove;
    }
}
