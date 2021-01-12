package com.lab5.figure;

public class Point2D extends Point {
    private double x, y;

    public Point2D(double x, double y) {
        super(new double[] {x, y});
        this.x = x;
        this.y = y;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }
}
