package com.lab5.gui;

import com.lab5.figure.Figure;

import javax.swing.*;
import java.awt.*;
import java.util.List;

public class MainPanel extends JPanel {

    List<Figure> figures;

    public MainPanel(List<Figure> figures) {
        this.figures = figures;
        this.setVisible(true);
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        for (Figure figure :
                figures) {
            figure.Draw(g);
        }
    }
}
