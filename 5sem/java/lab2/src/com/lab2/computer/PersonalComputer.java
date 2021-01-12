package com.lab2.computer;

import com.lab2.component.Component;
import com.lab2.component.storage.DataStorage;
import com.lab2.component.storage.HDD;

import java.util.List;

public class PersonalComputer extends Computer {
    public PersonalComputer(List<Component> components) {
        super(components);
    }

    public void virusCheck() throws Exception {
        if(isLaunched) {
            for (Component component:
                 components) {
                if(component instanceof HDD) {
                    ((HDD) component).checkForViruses();
                }
            }
        }
        else {
            throw new Exception("Launch computer first");
        }
    }

    public void getDisksSizes() throws Exception{
        if(isLaunched) {
            for (Component component:
                    components) {
                if(component instanceof HDD) {
                    System.out.println(((HDD) component).getSize());
                }
            }
        }
        else {
            throw new Exception("Launch computer first");
        }
    }
}
