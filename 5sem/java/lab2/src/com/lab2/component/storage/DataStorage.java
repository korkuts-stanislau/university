package com.lab2.component.storage;

import com.lab2.component.Component;

public abstract class DataStorage extends Component {
    int size;

    public int getSize() {
        return size;
    }

    public DataStorage(String name, String description, double price, int sizeInGb) {
        super(name, description, price);
        this.size = sizeInGb;
    }

    public void checkForViruses() {
        System.out.println(name + " checked for viruses.");
    }

    @Override
    public String toString() {
        return String.format("DataStorage\n%s\n%s\nPrice: %.2f\nSize in GB: %d", name, description, price, size);
    }
}
