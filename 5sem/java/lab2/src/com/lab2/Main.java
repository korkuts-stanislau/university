package com.lab2;

import com.lab2.component.Component;
import com.lab2.component.peripheral.DVDROM;
import com.lab2.component.storage.HDD;
import com.lab2.component.storage.RAM;
import com.lab2.computer.Computer;
import com.lab2.computer.PersonalComputer;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<Component> components = new ArrayList<>();
        components.add(new DVDROM("DVDM11", "Simple dvd rom", 30));
        components.add(new RAM("Kingston", "Powerfull ram", 200, 16, RAM.RAMType.DDR4));
        components.add(new HDD("WD Blue", "Simple hdd", 100, 1024, 7200));
        PersonalComputer computer = new PersonalComputer(components);
        computer.launch();
        try {
            computer.getDisksSizes();
        }
        catch(Exception exception) {
            System.out.println(exception.getMessage());
        }
        try {
            computer.virusCheck();
        }
        catch(Exception exception) {
            System.out.println(exception.getMessage());
        }
        computer.switchOff();
        try {
            computer.getDisksSizes();
        }
        catch(Exception exception) {
            System.out.println(exception.getMessage());
        }
    }
}
