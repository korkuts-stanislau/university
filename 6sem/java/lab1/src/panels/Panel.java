package panels;

import java.util.Scanner;

public abstract class Panel {
    private int phoneCode = 37542;
    private Scanner reader;

    public Panel() {
        reader = new Scanner(System.in);
    }

    public int getPhoneCode() {
        return phoneCode;
    }

    public void setPhoneCode(int phoneCode) {
        this.phoneCode = phoneCode;
    }

    public Scanner getReader() {
        return reader;
    }

    public void setReader(Scanner reader) {
        this.reader = reader;
    }

    public abstract void menu();
}
