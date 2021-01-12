package com.lab1;

import com.lab1.client.OrdinalClient;
import com.lab1.client.SimpleAddress;
import com.lab1.phone.MobilePhone;
import com.lab1.phone.Phone;
import com.lab1.phone.PhoneCalls;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<Phone> phones = getPhones();
        task1(phones, 14);
        task2(phones);
        task3(phones);
    }

    private static List<Phone> getPhones() {
        List<Phone> phones = new ArrayList<>();
        phones.add(new MobilePhone(new OrdinalClient("Stanislau", "Korkuts", "Igorevich",
                "5545768709883728", new SimpleAddress("Belarus", "Gomel", "Oktyabrya",
                48)), -10, new PhoneCalls(15, 0)));
        phones.add(new MobilePhone(new OrdinalClient("Kirill", "Korkuts", "Feliksovich",
                "5545768700213715", new SimpleAddress("Belarus", "Oktyabrsky", "Sovhoznaya",
                17)), 15, new PhoneCalls(21, 5)));
        phones.add(new MobilePhone(new OrdinalClient("Kirill", "Lukyanuk", "Dmitrievich",
                "5545768729854785", new SimpleAddress("Belarus", "Gomel", "Oktyabrya",
                48)), 5, new PhoneCalls(9, 13)));
        return phones;
    }

    private static void task1(List<Phone> phones, int cityCalls) {
        System.out.println("\nTASK 1\n");
        for (Phone phone :
                phones) {
            if(phone.getCalls().getCityCalls() > cityCalls) {
                System.out.println(phone);
            }
        }
    }

    private static void task2(List<Phone> phones) {
        System.out.println("\nTASK 2\n");
        for (Phone phone : phones) {
            if(phone.getCalls().getInternationalCalls() > 0) {
                System.out.println(phone);
            }
        }
    }

    private static void task3(List<Phone> phones) {
        System.out.println("\nTASK 3\n");
        phones.sort(null);
        for (Phone phone : phones) {
                System.out.println(phone);
        }
    }
}
