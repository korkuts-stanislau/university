package users;

import station.PhoneService;
import users.requests.DeclineServiceRequest;
import users.requests.PhoneChangeRequest;
import users.requests.Request;

import java.util.ArrayList;
import java.util.List;

public class Admin extends User{

    public Admin() {

    }

    public Admin(String username, String password) {
        super(username, password);
    }

    public void handleRequest(List<Subscriber> subs, Request request) throws Exception {
        Subscriber sub = null;
        for (Subscriber s :
                subs) {
            if (s.getUsername().equals(request.getUsername())) {
                sub = s;
                break;
            }
        }
        if(sub == null) {
            throw new Exception("Нет пользователя с таким именем");
        }
        if(request instanceof PhoneChangeRequest) {
            PhoneChangeRequest req = (PhoneChangeRequest) request;
            sub.setPhoneNumber(req.getNewPhoneNumber());
        }
        if(request instanceof DeclineServiceRequest) {
            DeclineServiceRequest req = (DeclineServiceRequest) request;
            List<PhoneService> subServices = sub.getServices();
            subServices.stream()
                    .filter(s -> s.getName().equals(req.getPhoneServiceToRemove().getName()))
                    .forEach(s -> subServices.remove(s));
        }
    }

    public void disconnectSubscriber(Subscriber sub) throws Exception {
        sub.makeUserDisconnected();
    }

    public List<Subscriber> getDebtors(List<Subscriber> subs) {
        List<Subscriber> debtors = new ArrayList<>();
        for (Subscriber sub :
                subs) {
            if(sub.getPhoneCallDebt() > 0) {
                debtors.add(sub);
            }
        }
        return debtors;
    }
}
