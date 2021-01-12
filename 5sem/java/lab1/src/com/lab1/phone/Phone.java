package com.lab1.phone;

import com.lab1.client.Client;

public abstract class Phone implements Comparable<Phone> {
    private static int lastId = 0;
    private int id;
    private Client client;
    private int accountBalance;
    private PhoneCalls calls;

    public Phone(Client client, int accountBalance, PhoneCalls calls) {
        id = lastId++;
        this.client = client;
        this.accountBalance = accountBalance;
        this.calls = calls;
    }

    public int getId() {
        return id;
    }

    public Client getPerson() {
        return client;
    }

    public int getAccountBalance() {
        return accountBalance;
    }

    public PhoneCalls getCalls() {
        return calls;
    }

    @Override
    public String toString() {
        return String.format("Id: %d\n%s\nBalance: %d\n%s", id, client, accountBalance, calls);
    }

    @Override
    public int compareTo(Phone o) {
        return client.getLastName().compareTo(o.getPerson().getLastName());
    }
}
