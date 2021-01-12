package com.lab4.matrix;

public abstract class Matrix {
    String name;
    int rows;
    int columns;

    public Matrix(String name, double[][] matrix) {
        this.name = name;
        rows = matrix.length;
        columns = matrix[0].length;
    }

    public Matrix(String name, int rows, int columns) {
        this.name = name;
        this.rows = rows;
        this.columns = columns;
    }

    public abstract Matrix transpose();

    public abstract double getValueAt(int row, int column) throws IndexOutOfBoundsException;
}
