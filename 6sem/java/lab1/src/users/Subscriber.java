package users;

import station.PhonePlan;
import station.PhoneService;

import java.util.List;

public class Subscriber extends User{
    private String _phoneNumber;
    private double _accountMoney;
    private double _phoneCallSeconds;
    private boolean _isServicesPaid;
    private final List<PhoneService> _services;
    private PhonePlan _phonePlan;

    public Subscriber(String username, String password, String phoneNumber, double accountMoney, double phoneCallSeconds,
                      List<PhoneService> services, PhonePlan phonePlan) {
        super(username, password);
        _phoneNumber = phoneNumber;
        _accountMoney = accountMoney;
        _phoneCallSeconds = phoneCallSeconds;
        _services = services;
        _phonePlan = phonePlan;
    }

    public String getPhoneNumber() {
        return _phoneNumber;
    }

    public double getAccountMoney() {
        return _accountMoney;
    }

    public double getPhoneCallSeconds() {
        return _phoneCallSeconds;
    }

    public List<PhoneService> getServices() {
        return _services;
    }

    public boolean isServicesPaid() {
        return _isServicesPaid;
    }

    public double getPhoneCallDebt() {
        return _phoneCallSeconds * _phonePlan.getPricePerCallSecond();
    }

    public void addService(PhoneService service) throws Exception{
        if(_services.contains(service)) {
            throw new Exception("Уже есть такая услуга");
        }
        _services.add(service);
    }

    public void removeService(PhoneService service) throws Exception{
        if(!_services.contains(service)) {
            throw new Exception("Абонент не подключен к этой услуге");
        }
        _services.remove(service);
    }

    public void makeServicesUnpaid() throws Exception {
        if(!_isServicesPaid) {
            throw new Exception("Услуги уже неоплачены");
        }
        _isServicesPaid = false;
    }

    public void payForServices() throws Exception {
        if(_isServicesPaid) {
            throw new Exception("Услуги уже оплачены");
        }
        double servicesPrice = 0;
        for (PhoneService service :
                _services) {
            servicesPrice += service.getPrice();
        }
        if(servicesPrice > _accountMoney) {
            throw new Exception("Недостаточно денег на счёте");
        }
        _accountMoney -= servicesPrice;
        _isServicesPaid = true;
    }

    public void changePhoneNumber(String newPhoneNumber) throws Exception {
        if(newPhoneNumber.equals(_phoneNumber)) {
            throw new Exception("Поптыка изменения номера на текущий номер");
        }
        _phoneNumber = newPhoneNumber;
    }

    public void changePhonePlan(PhonePlan plan) throws Exception {
        if(plan.equals(_phonePlan)) {
            throw new Exception("Такой тарифный план уже установлен");
        }
        _phonePlan = plan;
    }

    public void payForPhonePlan() throws Exception {
        double debt = getPhoneCallDebt();
        if(debt > _accountMoney) {
            throw new Exception("Недостаточно денег на счёте");
        }
        _accountMoney -= debt;
        _phoneCallSeconds = 0;
    }

    public void topUpAccountMoney(double money) throws Exception {
        if(money <= 0) {
            throw new Exception("Сумма пополнения должна быть больше нуля");
        }
        _accountMoney += money;
    }

    public void makePhoneCall(int seconds) throws Exception {
        if(seconds < 1) {
            throw new Exception("Разговор не может длиться меньше одной секунды");
        }
        _phoneCallSeconds += seconds;
    }
}
