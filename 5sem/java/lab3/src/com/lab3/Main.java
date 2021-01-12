package com.lab3;

public class Main {

    public static void main(String[] args) {
        Cipher cipher = new Cipher(new TaskCipherStrategy());
        System.out.println(cipher.encrypt("123123123"));
        System.out.println(cipher.encrypt("Hello world"));
    }
}
