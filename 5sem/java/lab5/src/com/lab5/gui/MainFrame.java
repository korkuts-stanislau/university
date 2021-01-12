package com.lab5.gui;

import com.lab5.figure.Figure;

import javax.swing.*;
import java.util.List;

public class MainFrame extends JFrame {

    MainPanel panel;

    public MainFrame(List<Figure> figures) {
        this.setVisible(true);
        this.setSize(800, 450);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        panel = new MainPanel(figures);
        add(panel);
    }

    public void updateDrawPanel() {
        panel.revalidate();
        panel.repaint();
    }
}
