package data;

import com.fasterxml.jackson.databind.ObjectMapper;
import station.PhonePlan;
import users.Admin;
import users.Subscriber;
import users.User;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class DataStorage {
    public List<User> getUsers() throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        BufferedReader adminsFile = new BufferedReader(new FileReader(path.commonPath + path.pathToAdmins));
        Admin[] admins = mapper.readValue(adminsFile, Admin[].class);

        BufferedReader subscribersFile = new BufferedReader(new FileReader(path.commonPath + path.pathToSubscribers));
        Subscriber[] subs = mapper.readValue(subscribersFile, Subscriber[].class);

        List<User> users = new ArrayList<>();
        users.addAll(Arrays.asList(admins));
        users.addAll(Arrays.asList(subs));

        return users;
    }

    public void saveUsers(List<User> users) throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        List<Admin> admins = new ArrayList<>();
        List<Subscriber> subs = new ArrayList<>();

        for (User user :
                users) {
            if(user instanceof Admin) {
                admins.add((Admin)user);
            }
            else if(user instanceof Subscriber) {
                subs.add((Subscriber)user);
            }
        }

        BufferedWriter adminsFile = new BufferedWriter(new FileWriter(path.commonPath + path.pathToAdmins));
        BufferedWriter subscribersFile = new BufferedWriter(new FileWriter(path.commonPath + path.pathToSubscribers));

        mapper.writeValue(adminsFile, admins);
        mapper.writeValue(subscribersFile, subs);
    }

    public List<PhonePlan> getPhonePlans() throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        BufferedReader phonePlansFile = new BufferedReader(new FileReader(path.commonPath + path.pathToPhonePlans));
        PhonePlan[] plans = mapper.readValue(phonePlansFile, PhonePlan[].class);

        return Arrays.asList(plans);
    }

    public void savePhonePlans(List<PhonePlan> phonePlans) throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        BufferedWriter phonePlansFile = new BufferedWriter(new FileWriter(path.commonPath + path.pathToPhonePlans));

        mapper.writeValue(phonePlansFile, phonePlans);
    }
}
