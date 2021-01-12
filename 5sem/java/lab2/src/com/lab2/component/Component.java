package com.lab2.component;

public abstract class Component {
    protected String name;
    protected String description;
    protected double price;

    public Component(String name, String description, double price) {
        this.name = name;
        this.description = description;
        this.price = price;
    }

    @Override
    public String toString() {
        return String.format("Component\n%s\n%s\nPrice: %.2f", name, description, price);
    }
}
