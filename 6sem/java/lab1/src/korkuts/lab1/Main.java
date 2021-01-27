package korkuts.lab1;

import data.Path;

public class Main {

    public static void main(String[] args) {
        System.out.println("Hello world");
        try {
            Path path = Path.getPath();
            System.out.println(path.commonPath);
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }
}
