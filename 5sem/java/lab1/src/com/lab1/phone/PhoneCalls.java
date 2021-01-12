package com.lab1.phone;

public class PhoneCalls {
    private int cityCalls;
    private int internationalCalls;

    public PhoneCalls(int cityCalls, int internationalCalls) {
        this.cityCalls = cityCalls;
        this.internationalCalls = internationalCalls;
    }

    public int getCityCalls() {
        return cityCalls;
    }

    public int getInternationalCalls() {
        return internationalCalls;
    }

    @Override
    public String toString() {
        return String.format("Calls. City calls: %d. International calls: %d.", cityCalls, internationalCalls);
    }
}
