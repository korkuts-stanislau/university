package com.lab5;

import com.lab5.figure.Figure;
import com.lab5.figure.NAngle;
import com.lab5.figure.Point2D;
import com.lab5.gui.MainFrame;

import java.awt.*;
import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Menu {
    Scanner in;
    List<Figure> figures;
    MainFrame frame;

    public Menu() {
        in = new Scanner(System.in);
        figures = new ArrayList<>();
        frame = new MainFrame(figures);
    }

    public void menu() {
        int result;
        do {
            System.out.println("Меню");
            printMenuItems();
            result = in.nextInt();
            switch (result) {
                case 1 -> addFigureAndUpdateDrawPanel();
                case 2 -> printMaxAreaFigure();
            }
        }
        while (result != 3);
    }

    public void printMenuItems() {
        System.out.println("1.Добавить фигуру");
        System.out.println("2.Вычислить фигуру, у которой самая большая площадь");
        System.out.println("3.Выход");
    }

    public void addFigureAndUpdateDrawPanel() {
        String name;
        System.out.println("Введите название новой фигуры");
        name = in.next();
        String strColor;
        System.out.println("Введите цвет новой фигуры");
        strColor = in.next();
        Color color;
        try {
            color = getColorFromString(strColor);
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
            return;
        }
        int pointsQuantity;
        System.out.println("Введите количество точек новой фигуры");
        pointsQuantity = in.nextInt();
        if(pointsQuantity < 3) {
            System.out.println("Не может быть меньше 3 точек");
            return;
        }
        List<Point2D> points = new ArrayList<>();
        for(int i = 0; i < pointsQuantity; i++) {
            System.out.println(String.format("Введите координаты точки номер %d через пробел", i + 1));
            double x, y;
            x = in.nextDouble();
            y = in.nextDouble();
            points.add(new Point2D(x, y));
        }
        try {
            figures.add(new NAngle(points, name, color));
        }
        catch (Exception exception) {
            System.out.println("Неправильная фигура");
            System.out.println(exception.getMessage());
        }
        frame.updateDrawPanel();
    }

    private Color getColorFromString(String colorStr) throws Exception {
        Color color;
        Field field = Color.class.getField(colorStr);
        return (Color)field.get(null);
    }

    public void printMaxAreaFigure() {
        Figure maxAreaFigure = null;
        double maxArea = 0;
        for (Figure figure :
                figures) {
            if(figure.getArea() > maxArea) {
                maxArea = figure.getArea();
                maxAreaFigure = figure;
            }
        }
        System.out.println("Фигура с самой большой площадью: " + maxAreaFigure);
    }

}
