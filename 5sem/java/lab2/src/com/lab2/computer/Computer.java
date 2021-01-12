package com.lab2.computer;

import com.lab2.component.Component;

import java.util.List;

public abstract class Computer {
    boolean isLaunched = false;
    List<Component> components;

    public Computer(List<Component> components) {
        this.components = components;
    }

    public void launch() {
        isLaunched = true;
    }

    public void switchOff() {
        isLaunched = false;
    }
}
