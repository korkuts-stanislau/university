package com.lab3;

public abstract class CipherStrategy {
    public abstract String encrypt(String text);
    public abstract String decrypt(String text);
}
