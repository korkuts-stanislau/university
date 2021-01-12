package com.lab2.component.peripheral;

import com.lab2.component.Component;

public class DVDROM extends Component {
    public DVDROM(String name, String description, double price) {
        super(name, description, price);
    }

    @Override
    public String toString() {
        return String.format("DVDROM\n%s\n%s\nPrice: %.2f", name, description, price);
    }
}
