package com.lab2.component.storage;

public class RAM extends DataStorage {
    public enum RAMType {
        DDR1, DDR2, DDR3, DDR4
    }

    RAMType type;

    public RAM(String name, String description, double price, int sizeInGb, RAMType type) {
        super(name, description, price, sizeInGb);
        this.type = type;
    }

    @Override
    public String toString() {
        return String.format("RAM\n%s\n%s\nPrice: %.2f\nSize: %d\nType: %s", name, description, price, size, type.toString());
    }
}
