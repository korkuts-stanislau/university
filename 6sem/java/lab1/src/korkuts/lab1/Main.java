package korkuts.lab1;

import data.DataStorage;
import data.Path;
import station.PhonePlan;
import station.PhoneService;
import users.Admin;
import users.Subscriber;
import users.User;
import users.requests.DeclineServiceRequest;
import users.requests.Request;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        System.out.println("Hello world");
        primaryDataInitialization();
    }

    private static void primaryDataInitialization() {
        try {
            Path path = Path.getPath();
            System.out.println(path.commonPath);
            DataStorage storage = new DataStorage();

            List<PhonePlan> phonePlans = new ArrayList<>();
            phonePlans.add(new PhonePlan("Базовый", "Обычный абонентский план", 0.11));
            phonePlans.add(new PhonePlan("Роуминг", "Абонентский план с роумингом", 0.52));
            storage.savePhonePlans(phonePlans);

            List<PhoneService> services = new ArrayList<>();
            services.add(new PhoneService("Интернет10", "Пакет интернета 10Гб на месяц", 4.99));
            services.add(new PhoneService("Интернет20", "Пакет интернета 20Гб на месяц", 9.99));
            services.add(new PhoneService("Интернет50", "Пакет интернета 50Гб на месяц", 19.99));
            storage.savePhoneServices(services);

            List<User> users = new ArrayList<>();
            users.add(new Admin("admin", "admin"));
            users.add(new Subscriber("stas", "lab1", "+375447776666", 10, 134,
                    new ArrayList<PhoneService>(), phonePlans.get(0), false));
            storage.saveUsers(users);


        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }
}
