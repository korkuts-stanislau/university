package com.lab5.figure;

import java.awt.*;

public abstract class Figure {
    String name;
    Color color;

    public Figure(String name, Color color) {
        this.name = name;
        this.color = color;
    }

    public abstract void Draw(Graphics g);
    public abstract double getArea();
}
