package users;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.databind.annotation.JsonSerialize;
import station.PhonePlan;
import station.PhoneService;
import users.requests.DeclineServiceRequest;
import users.requests.PhoneChangeRequest;
import users.requests.Request;

import java.util.List;
import java.util.stream.Collectors;

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
                      List<PhoneService> services, PhonePlan phonePlan, boolean isUserDisconnected, boolean isServicesPaid) {
        super(username, password);
        _phoneNumber = phoneNumber;
        _accountMoney = accountMoney;
        _phoneCallSeconds = phoneCallSeconds;
        _services = services;
        _phonePlan = phonePlan;
        _isUserDisconnected = isUserDisconnected;
        _isServicesPaid = isServicesPaid;
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
        if(_services.stream().map(s -> s.getName()).collect(Collectors.toList()).contains(service.getName())) {
            throw new Exception("Уже есть такая услуга");
        }
        _services.add(service);
    }

    public Request removeServiceRequest(PhoneService service) throws Exception{
        if(!_services.stream().map(s -> s.getName()).collect(Collectors.toList()).contains(service.getName())) {
            throw new Exception("Абонент не подключен к этой услуге");
        }
        return new DeclineServiceRequest(getUsername(), service);
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

    public Request changePhoneNumberRequest(String newPhoneNumber) throws Exception {
        if(newPhoneNumber.equals(_phoneNumber)) {
            throw new Exception("Попытка изменения номера на текущий номер");
        }
        return new PhoneChangeRequest(this.getUsername(), _phoneNumber);
    }

    public void changePhonePlan(PhonePlan plan) throws Exception {
        if(plan.getName().equals(_phonePlan.getName())) {
            throw new Exception("Такой тарифный план уже установлен");
        }
        _phonePlan = plan;
    }

    public void payForPhonePlan() throws Exception {
        double debt = getPhoneCallDebt();
        if(debt > _accountMoney) {
            throw new Exception("Недостаточно денег на счёте");
        }
        if(debt == 0) {
            throw new Exception("Всё оплачено");
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

    @Override
    public String toString() {
        return "Аккаунт пользователя " + getUsername() + ":" +
                "\nНомер телефона='" + _phoneNumber + '\'' +
                "\nОстаток на счёте=" + _accountMoney +
                "\nКоличество неоплаченных секунд=" + _phoneCallSeconds +
                "\nОплачены ли сервисы=" + (_isServicesPaid ? "Да" : "Нет") +
                "\nСписок сервисов=" + _services +
                "\nТарифный план=" + _phonePlan +
                "\nСостояние аккаунта=" + (_isUserDisconnected ? "Отключен" : "Подключен") +
                '}';
    }
}
