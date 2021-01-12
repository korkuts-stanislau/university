package com.lab2.component.storage;

public class HDD extends DataStorage {
    int HDDSpeed;

    public HDD(String name, String description, double price, int sizeInGb, int HDDSpeed) {
        super(name, description, price, sizeInGb);
        this.HDDSpeed = HDDSpeed;
    }

    @Override
    public String toString() {
        return String.format("RAM\n%s\n%s\nPrice: %.2f\nSize: %d\nSpeed: %s", name, description, price, size, HDDSpeed);
    }
}
