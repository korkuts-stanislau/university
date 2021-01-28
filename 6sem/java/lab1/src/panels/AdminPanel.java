package panels;

import data.DataStorage;
import users.Admin;
import users.Subscriber;
import users.User;
import users.requests.Request;

import java.util.ArrayList;
import java.util.List;

public class AdminPanel extends Panel{
    private Admin admin;

    public AdminPanel(Admin adm) {
        admin = adm;
    }

    @Override
    public void menu() {
        while(true) {
            System.out.println("Меню");
            System.out.println("1. Посмотреть список должников");
            System.out.println("2. Отключить пользователя");
            System.out.println("3. Принять запрос");
            System.out.println("4. Выход");
            System.out.println("Сделайте выбор");
            int choice;
            while(true){
                try{
                    choice = Integer.parseInt(getReader().nextLine());
                    if(choice < 1 || choice > 4) throw new Exception("");
                    break;
                }
                catch (Exception exception) {
                    System.out.println("Вы ввели неверное значение, попробуйте снова");
                }
            }
            switch (choice) {
                case 1:
                    showDebtors();
                    break;
                case 2:
                    disableUser();
                    break;
                case 3:
                    acceptRequest();
                    break;
                case 4:
                    return;
                default: break;
            }
        }
    }

    private void acceptRequest() {
        try{

            System.out.println("Список запросов");
            DataStorage storage = new DataStorage();
            List<User> users = storage.getUsers();
            List<Subscriber> subs = new ArrayList<>();
            List<Admin> admins = new ArrayList<>();
            for (User user :
                    users) {
                if(user instanceof Subscriber) {
                    subs.add((Subscriber) user);
                }
                if(user instanceof Admin) {
                    admins.add((Admin) user);
                }
            }
            List<Request> requests = storage.getRequests();
            int i = 1;
            for (Request request :
                    requests) {
                System.out.printf("%d) %s\n\n", i, request.toString());
                i++;
            }
            int choice;
            while(true){
                try{
                    choice = Integer.parseInt(getReader().nextLine());
                    if(choice < 1 || choice > requests.size()) throw new Exception("");
                    break;
                }
                catch (Exception exception) {
                    System.out.println("Вы ввели неверное значение, попробуйте снова");
                }
            }
            admin.handleRequest(subs, requests.get(choice - 1));
            List<User> updatedUsers = new ArrayList<>();
            updatedUsers.addAll(subs);
            updatedUsers.addAll(admins);
            storage.saveUsers(updatedUsers);
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

    }

    private void disableUser() {
        try {
            DataStorage storage = new DataStorage();
            List<User> users = storage.getUsers();
            List<Subscriber> subs = new ArrayList<>();
            List<Admin> admins = new ArrayList<>();
            for (User user :
                    users) {
                if(user instanceof Subscriber) {
                    subs.add((Subscriber) user);
                }
                if(user instanceof Admin) {
                    admins.add((Admin) user);
                }
            }
            System.out.println("Выберите пользователя, которого необходимо временно отключить");
            int i = 1;
            for (Subscriber sub :
                    subs) {
                System.out.printf("%d) %s\n\n", i, sub.toString());
                i++;
            }
            int choice;
            while(true){
                try{
                    choice = Integer.parseInt(getReader().nextLine());
                    if(choice < 1 || choice > subs.size()) throw new Exception("");
                    break;
                }
                catch (Exception exception) {
                    System.out.println("Вы ввели неверное значение, попробуйте снова");
                }
            }
            admin.disconnectSubscriber(subs.get(choice - 1));
            List<User> updatedUsers = new ArrayList<>();
            updatedUsers.addAll(subs);
            updatedUsers.addAll(admins);
            storage.saveUsers(updatedUsers);
        }
        catch(Exception exception) {
            System.out.println(exception.getMessage());
        }
    }

    private void showDebtors() {
        try {
            DataStorage storage = new DataStorage();
            List<Subscriber> subs = new ArrayList<>();
            for (User user :
                    storage.getUsers()) {
                if(user instanceof Subscriber) {
                    subs.add((Subscriber) user);
                }
            }
            admin.getDebtors(subs);
            for (Subscriber sub :
                    subs) {
                System.out.println(sub.toString() + "\n");
            }
        }
        catch(Exception exception) {
            System.out.println(exception.getMessage());
        }
    }
}
