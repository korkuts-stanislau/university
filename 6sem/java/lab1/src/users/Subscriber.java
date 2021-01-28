package users;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.databind.annotation.JsonSerialize;
import station.PhonePlan;
import station.PhoneService;

import java.util.List;

public class Subscriber extends User{
    private String _phoneNumber;
    private double _accountMoney;
    private double _phoneCallSeconds;
    private boolean _isServicesPaid;
    private List<PhoneService> _services;
    private PhonePlan _phonePlan;
    private boolean _isUserDisconnected;

    public Subscriber() {
        
    }

    public Subscriber(String username, String password, String phoneNumber, double accountMoney, double phoneCallSeconds,
                      List<PhoneService> services, PhonePlan phonePlan, boolean isUserDisconnected) {
        super(username, password);
        _phoneNumber = phoneNumber;
        _accountMoney = accountMoney;
        _phoneCallSeconds = phoneCallSeconds;
        _services = services;
        _phonePlan = phonePlan;
        _isUserDisconnected = isUserDisconnected;
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

    public boolean getIsServicesPaid() {
        return _isServicesPaid;
    }

    @JsonIgnore
    public double getPhoneCallDebt() {
        return _phoneCallSeconds * _phonePlan.getPricePerCallSecond();
    }

    public PhonePlan getPhonePlan() {
        return _phonePlan;
    }

    public void setPhoneNumber(String phoneNumber) {
        _phoneNumber = phoneNumber;
    }

    public void setAccountMoney(double accountMoney) {
        _accountMoney = accountMoney;
    }

    public void setPhoneCallSeconds(double phoneCallSeconds) {
        _phoneCallSeconds = phoneCallSeconds;
    }

    public void setIsServicesPaid(boolean isServicesPaid) {
        _isServicesPaid = isServicesPaid;
    }

    public void setServices(List<PhoneService> services) {
        _services = services;
    }

    public void setPhonePlan(PhonePlan phonePlan) {
        _phonePlan = phonePlan;
    }

    public void setIsUserDisconnected(boolean isUserDisconnected) {
        _isUserDisconnected = isUserDisconnected;
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

    public void makeUserDisconnected() throws Exception {
        if(_isUserDisconnected) {
            throw new Exception("Пользователь уже отключён");
        }
        _isUserDisconnected = true;
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
            throw new Exception("Попытка изменения номера на текущий номер");
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
        if(_isUserDisconnected) {
            throw new Exception("Пользователь отключен из-за неуплаты услуг");
        }
        if(seconds < 1) {
            throw new Exception("Разговор не может длиться меньше одной секунды");
        }
        _phoneCallSeconds += seconds;
    }
}
