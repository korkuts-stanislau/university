package com.lab5.figure;

import java.awt.*;
import java.util.List;

public class Triangle extends NAngle {
    public Triangle(List<Point2D> points, String name, Color color) throws Exception {
        super(points, name, color);
        if(points.size() != 3)
            throw new Exception("У треугольника три точки");
    }
}
