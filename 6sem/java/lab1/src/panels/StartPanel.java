package panels;

import data.DataStorage;
import station.PhonePlan;
import station.PhoneService;
import users.Admin;
import users.Subscriber;
import users.User;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class StartPanel extends Panel {
    private final int _usernameMinLength = 4;
    private final int _passwordMinLength = 4;

    @Override
    public void menu() {
        while(true) {
            System.out.println("Меню");
            System.out.println("1. Войти");
            System.out.println("2. Регистрация");
            System.out.println("3. Выход");
            System.out.println("Сделайте выбор");
            int choice;
            while(true){
                try{
                    choice = Integer.parseInt(getReader().nextLine());
                    if(choice < 1 || choice > 3) throw new Exception("");
                    break;
                }
                catch (Exception exception) {
                    System.out.println("Вы ввели неверное значение, попробуйте снова");
                }
            }
            try {
                DataStorage storage = new DataStorage();
                User user;
                switch (choice) {
                    case 1:
                        user = authorize(storage.getUsers());
                        if(user instanceof Subscriber) {
                            Subscriber sub = (Subscriber) user;
                            SubscriberPanel panel = new SubscriberPanel(sub);
                            panel.menu();
                        }
                        if(user instanceof Admin) {
                            Admin admin = (Admin) user;
                            AdminPanel panel = new AdminPanel(admin);
                            panel.menu();
                        }
                        break;
                    case 2:
                        List<User> users = storage.getUsers();
                        user = register(users, storage.getPhonePlans());
                        users.add(user);
                        storage.saveUsers(users);
                        break;
                    case 3:
                        return;
                    default: break;
                }
            }
            catch (Exception exception) {
                System.out.println(exception.getMessage());
            }
        }
    }

    private User authorize(List<User> users) throws Exception {
        Scanner reader = new Scanner(System.in);

        System.out.println("Авторизация пользователя");
        System.out.println("Введите имя пользователя");
        String username = reader.nextLine();
        User user = null;
        for (User usr :
                users) {
            if(usr.getUsername().equals(username)) {
                user = usr;
            }
        }
        if(user == null) {
            throw new Exception("Нет пользователя с таким именем");
        }

        System.out.println("Введите пароль");
        String password = reader.nextLine();
        if(!user.getPassword().equals(password)) {
            throw new Exception("Неверный пароль пользователя, повторите попытку");
        }
        else{
            return user;
        }
    }

    private User register(List<User> users, List<PhonePlan> phonePlans) throws Exception {
        Scanner reader = new Scanner(System.in);

        System.out.println("Регистрация пользователя");
        System.out.println(String.format("Введите имя пользователя(%d и более символов)", _usernameMinLength));
        String username = reader.nextLine();
        if(username.length() < _usernameMinLength) {
            throw new Exception(String.format("Имя пользователя должно быть %d и более символов", _usernameMinLength));
        }
        for (User usr :
                users) {
            if(usr.getUsername().equals(username)) {
                throw new Exception("Уже есть пользователь с таким именем");
            }
        }

        System.out.println(String.format("Введите пароль(%d и более символов)", _passwordMinLength));
        String password = reader.nextLine();
        if(password.length() < _passwordMinLength) {
            throw new Exception(String.format("Имя пользователя должно быть %d и более символов", _passwordMinLength));
        }

        String phoneNumber = makeNewPhoneNumber(users);

        System.out.println("Выберите тариф");
        int i = 1;
        for (PhonePlan plan :
                phonePlans) {
            System.out.println(String.format("\n%d)%s\n%s\nЦена за одну секунду разговора %.3f", i, plan.getName(),
                    plan.getDescription(), plan.getPricePerCallSecond()));
            i++;
        }
        String choice = reader.nextLine();
        int choiceNumber;
        try {
            choiceNumber = Integer.parseInt(choice);
            if(choiceNumber < 1 || choiceNumber > phonePlans.size()) {
                throw new Exception();
            }
        }
        catch(Exception exception){
            throw new Exception("Введён неправильный номер тарифного плана");
        }
        PhonePlan phonePlan = phonePlans.get(choiceNumber - 1);

        System.out.println("Вы успешно зарегистрированы");
        return new Subscriber(username, password, phoneNumber, 0, 0,
                new ArrayList<PhoneService>(), phonePlan, false, true);
    }

    private String makeNewPhoneNumber(List<User> users) throws Exception {
        //phone number format   +375421234567
        List<Integer> phoneNumbersWithoutCode = new ArrayList<>();
        for (User usr :
                users) {
            if (usr instanceof Subscriber) {
                Subscriber sub = (Subscriber)usr;
                String phoneNumberWithoutCode = sub.getPhoneNumber().substring(6);
                phoneNumbersWithoutCode.add(Integer.parseInt(phoneNumberWithoutCode));
            }
        }
        for(int i = 1000000; i < 99999999; i++) {
            if(!phoneNumbersWithoutCode.contains(i)) {
                return String.format("+%d%d", getPhoneCode(), i);
            }
        }
        throw new Exception("Все номера закончились");
    }
}
