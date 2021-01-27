package data;

import com.fasterxml.jackson.databind.ObjectMapper;
import station.PhonePlan;
import station.PhoneService;
import users.Admin;
import users.Subscriber;
import users.User;
import users.requests.DeclineServiceRequest;
import users.requests.PhoneChangeRequest;
import users.requests.Request;

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

    public List<PhoneService> getPhoneServices() throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        BufferedReader phoneServicesFile = new BufferedReader(new FileReader(path.commonPath + path.pathToPhoneServices));
        PhoneService[] services = mapper.readValue(phoneServicesFile, PhoneService[].class);

        return Arrays.asList(services);
    }

    public void savePhoneServices(List<PhoneService> phoneServices) throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        BufferedWriter phoneServicesFile = new BufferedWriter(new FileWriter(path.commonPath + path.pathToPhoneServices));

        mapper.writeValue(phoneServicesFile, phoneServices);
    }

    public List<Request> getRequests() throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        BufferedReader declineRequestsFile = new BufferedReader(new FileReader(path.commonPath + path.pathToDeclineServiceRequests));
        DeclineServiceRequest[] declineServiceRequests = mapper.readValue(declineRequestsFile, DeclineServiceRequest[].class);

        BufferedReader phoneChangeRequestsFile = new BufferedReader(new FileReader(path.commonPath + path.pathToPhoneChangeRequests));
        PhoneChangeRequest[] phoneChangeRequests = mapper.readValue(phoneChangeRequestsFile, PhoneChangeRequest[].class);

        List<Request> requests = new ArrayList<>();
        requests.addAll(Arrays.asList(declineServiceRequests));
        requests.addAll(Arrays.asList(phoneChangeRequests));

        return requests;
    }

    public void saveRequests(List<Request> requests) throws Exception {
        Path path = Path.getPath();
        ObjectMapper mapper = new ObjectMapper();

        List<DeclineServiceRequest> declineServiceRequests = new ArrayList<>();
        List<PhoneChangeRequest> phoneChangeRequests = new ArrayList<>();

        for (Request request :
                requests) {
            if(request instanceof DeclineServiceRequest) {
                declineServiceRequests.add((DeclineServiceRequest)request);
            }
            else if(request instanceof PhoneChangeRequest) {
                phoneChangeRequests.add((PhoneChangeRequest)request);
            }
        }

        BufferedWriter declineServiceRequestsFile = new BufferedWriter(new FileWriter(path.commonPath + path.pathToDeclineServiceRequests));
        BufferedWriter phoneChangeRequestsFile = new BufferedWriter(new FileWriter(path.commonPath + path.pathToPhoneChangeRequests));

        mapper.writeValue(declineServiceRequestsFile, declineServiceRequests);
        mapper.writeValue(phoneChangeRequestsFile, phoneChangeRequests);
    }
}
