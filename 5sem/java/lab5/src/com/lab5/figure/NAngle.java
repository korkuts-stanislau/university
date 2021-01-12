package com.lab5.figure;

import java.awt.*;
import java.util.List;

public class NAngle extends Figure {
    private List<Point2D> points;

    public NAngle(List<Point2D> points, String name, Color color) throws Exception {
        super(name, color);
        if(points.size() < 3)
            throw new Exception("У многоугольника минимум 3 точки");
        this.points = points;
    }

    @Override
    public void Draw(Graphics g) {
        var g2d = (Graphics2D)g;
        g2d.setColor(color);
        g2d.drawLine((int)points.get(0).getX(), (int)points.get(0).getY(),
                (int)points.get(points.size() - 1).getX(), (int)points.get(points.size() - 1).getY());
        for(int i = 1; i < points.size(); i++) {
            g2d.drawLine((int)points.get(i).getX(), (int)points.get(i).getY(),
                    (int)points.get(i - 1).getX(), (int)points.get(i - 1).getY());
        }
    }

    @Override
    public double getArea() {
        //Площадь n угольника вычисляется по формуле Гаусса
        double accum = 0;
        for(int i = 0; i < points.size() - 1; i++) {
            accum += points.get(i).getX() * points.get(i + 1).getY();
        }
        accum += points.get(points.size() - 1).getX() * points.get(0).getY();
        for(int i = 0; i < points.size() - 1; i++) {
            accum -= points.get(i + 1).getX() * points.get(i).getY();
        }
        accum -= points.get(0).getX() * points.get(points.size() - 1).getY();
        return 0.5 * Math.abs(accum);
    }

    @Override
    public String toString() {
        return String.format("это фигура %s у которой %d точек. Площадь фигуры %.2f.", name, points.size(), getArea());
    }
}
