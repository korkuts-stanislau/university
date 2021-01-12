package com.lab1.client;

public abstract class Client {
    private String firstName;
    private String secondName;
    private String lastName;
    private String creditCardNumber;
    private Address address;

    public Client(String firstName, String secondName, String lastName, String creditCardNumber, Address address) {
        this.firstName = firstName;
        this.secondName = secondName;
        this.lastName = lastName;
        this.creditCardNumber = creditCardNumber;
        this.address = address;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getSecondName() {
        return secondName;
    }

    public String getLastName() {
        return lastName;
    }

    public String getCreditCardNumber() {
        return creditCardNumber;
    }

    public Address getAddress() {
        return address;
    }

    @Override
    public String toString() {
        return String.format("Person: %s %s %s %s. %s", secondName, firstName, lastName, creditCardNumber, address);
    }
}
