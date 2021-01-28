package panels;

import data.DataStorage;
import station.PhoneService;
import users.Subscriber;
import users.requests.Request;

import java.util.List;
import java.util.Scanner;

public class SubscriberPanel extends Panel {
    private Subscriber subscriber;

    public SubscriberPanel(Subscriber sub) {
        subscriber = sub;
    }

    @Override
    public void menu() {
        while(true) {
            System.out.println("Меню");
            System.out.println("1. Информация об аккаунте");
            System.out.println("2. Позвонить");
            System.out.println("3. Пополнить счёт");
            System.out.println("4. Оплатить тариф");
            System.out.println("5. Оплатить услуги");
            System.out.println("6. Сменить номер");
            System.out.println("7. Отказаться от услуги");
            System.out.println("8. Выход");
            System.out.println("Сделайте выбор");
            int choice;
            while(true){
                try{
                    choice = Integer.parseInt(getReader().nextLine());
                    if(choice < 1 || choice > 8) throw new Exception("");
                    break;
                }
                catch (Exception exception) {
                    System.out.println("Вы ввели неверное значение, попробуйте снова");
                }
            }
            switch (choice) {
                case 1:
                    showSubInfo();
                    break;
                case 2:
                    makeCall();
                    break;
                case 3:
                    topUpAccount();
                    break;
                case 4:
                    payForPlan();
                    break;
                case 5:
                    payForServices();
                    break;
                case 6:
                    changePhoneNumber();
                    break;
                case 7:
                    declineService();
                    break;
                case 8:
                    return;
                default: break;
            }
        }
    }

    private void showSubInfo() {
        System.out.println(subscriber.toString());
    }

    private void makeCall() {
        System.out.println("Сколько секунд вы хотите говорить?");
        int seconds;
        while(true){
            try{
                seconds = Integer.parseInt(getReader().nextLine());
                if(seconds < 1) throw new Exception("");
                break;
            }
            catch (Exception exception) {
                System.out.println("Вы ввели неверное значение, попробуйте снова");
            }
        }
        try {
            subscriber.makePhoneCall(seconds);
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }

    private void topUpAccount() {
        System.out.println("Сколько вы хотите зачислить на счёт?");
        double money;
        while(true){
            try{
                money = Double.parseDouble(getReader().nextLine());
                if(money < 0) throw new Exception("");
                break;
            }
            catch (Exception exception) {
                System.out.println("Вы ввели неверное значение, попробуйте снова");
            }
        }
        try {
            subscriber.topUpAccountMoney(money);
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }

    private void payForPlan() {
        try {
            subscriber.payForPhonePlan();
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }

    private void payForServices() {
        try {
            subscriber.payForServices();
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }

    private void changePhoneNumber() {
        System.out.println("Введите желаемый номер телефона в виде 7 или 8 цифр идущих за +37542");
        int phoneNumber;
        while(true){
            try{
                String number = getReader().nextLine();
                if(number.length() < 7 || number.length() > 8) {
                    throw new Exception("");
                }
                phoneNumber = Integer.parseInt(number);
                if(phoneNumber < 0) throw new Exception("");
                break;
            }
            catch (Exception exception) {
                System.out.println("Вы ввели неверное значение, попробуйте снова");
            }
        }
        try {
            Request request = subscriber.changePhoneNumberRequest(String.format("+%d%d", getPhoneCode(), phoneNumber));
            DataStorage storage = new DataStorage();
            List<Request> requests = storage.getRequests();
            requests.add(request);
            storage.saveRequests(requests);
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }

    private void declineService() {
        System.out.println("Выберите из своего списка сервисов от которого хотите отказаться");
        if(subscriber.getServices().size() == 0) {
            System.out.println("Нет сервисов");
            return;
        }
        int i = 1;
        for (PhoneService service :
                subscriber.getServices()) {
            System.out.println("1. " + service.toString());
            i++;
        }
        int choice;
        while(true){
            try{
                choice = Integer.parseInt(getReader().nextLine());
                if(choice < 1 || choice > subscriber.getServices().size()) throw new Exception("");
                break;
            }
            catch (Exception exception) {
                System.out.println("Вы ввели неверное значение, попробуйте снова");
            }
        }
        try {
            Request request = subscriber.removeServiceRequest(subscriber.getServices().get(choice - 1));
            DataStorage storage = new DataStorage();
            List<Request> requests = storage.getRequests();
            requests.add(request);
            storage.saveRequests(requests);
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }
}
