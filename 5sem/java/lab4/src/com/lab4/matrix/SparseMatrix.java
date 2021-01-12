package com.lab4.matrix;

import java.util.ArrayList;
import java.util.List;

public class SparseMatrix extends Matrix {
    List<SparseMatrixElement> elements;

    public SparseMatrix(String name, int rows, int columns, List<SparseMatrixElement> elements) {
        super(name, rows, columns);
        this.elements = elements;
    }

    public SparseMatrix(String name, double[][] matrix) {
        super(name, matrix);
        this.elements = new ArrayList<>();
        for (int i = 0; i < rows; i++) {
            for(int j = 0; j < columns; j++) {
                if(matrix[i][j] != 0) {
                    elements.add(new SparseMatrixElement(i, j, matrix[i][j]));
                }
            }
        }
    }

    @Override
    public Matrix transpose() {
        List<SparseMatrixElement> newElements = new ArrayList<>();
        for (SparseMatrixElement element:
             this.elements) {
             newElements.add(new SparseMatrixElement(element.columnIndex, element.rowIndex, element.value));
        }
        return new SparseMatrix("Transposed " + this.name, this.columns, this.rows, newElements);
    }

    @Override
    public double getValueAt(int row, int column) throws IndexOutOfBoundsException {
        if(row > rows || column > columns || row < 0 || column < 0) {
            throw new IndexOutOfBoundsException();
        }
        for (SparseMatrixElement element :
                elements) {
            if(element.rowIndex == row && element.columnIndex == column) {
                return element.value;
            }
        }
        return 0;
    }

    public static SparseMatrix sum(SparseMatrix firstMatrix, SparseMatrix secondMatrix) throws Exception {
        if(!(firstMatrix.rows == secondMatrix.rows && firstMatrix.columns == secondMatrix.columns)) {
            throw new Exception("Разные размеры матриц");
        }
        List<SparseMatrixElement> firstMatrixElements = new ArrayList<>(firstMatrix.elements);
        List<SparseMatrixElement> secondMatrixElements = new ArrayList<>(secondMatrix.elements);
        List<SparseMatrixElement> newMatrixElements = new ArrayList<>();
        for(int i = 0; i < firstMatrixElements.size(); i++) {
            boolean flag = true;
            for(int j = 0; j < secondMatrixElements.size(); j++) {
                if(firstMatrixElements.get(i).rowIndex == secondMatrixElements.get(j).rowIndex &&
                        firstMatrixElements.get(i).columnIndex == secondMatrixElements.get(j).columnIndex) {
                    newMatrixElements.add(SparseMatrixElement.add(firstMatrixElements.get(i), secondMatrixElements.get(j)));
                    secondMatrixElements.remove(secondMatrixElements.get(j));
                    flag = false;
                    break;
                }
            }
            if(flag) {
                newMatrixElements.add(firstMatrixElements.get(i));
            }
        }
        newMatrixElements.addAll(secondMatrixElements);
        return new SparseMatrix(firstMatrix.name + secondMatrix.name, firstMatrix.rows, firstMatrix.columns, newMatrixElements);
    }

    public static SparseMatrix prod(SparseMatrix firstMatrix, SparseMatrix secondMatrix) throws Exception {
        if(firstMatrix.columns != secondMatrix.rows) {
            throw new Exception("Матрицы не могут быть умножены");
        }
        double[][] matrix = new double[firstMatrix.rows][secondMatrix.columns];
        for(int i = 0; i < firstMatrix.rows; i++) {
            for(int j = 0; j < secondMatrix.columns; j++) {
                double accum = 0;
                for(int k = 0; k < firstMatrix.columns; k++) {
                    accum += firstMatrix.getValueAt(i, k) * secondMatrix.getValueAt(k, j);
                }
                matrix[i][j] = accum;
            }
        }
        return new SparseMatrix(firstMatrix.name + secondMatrix.name, matrix);
    }

    @Override
    public String toString() {
        double[][] matrix = new double[rows][columns];
        for (SparseMatrixElement element :
                elements) {
            matrix[element.rowIndex][element.columnIndex] = element.value;
        }
        StringBuilder builder = new StringBuilder();
        builder.append(String.format("Matrix name: %s\nSize: %dx%d\n", name, rows, columns));
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                builder.append(String.valueOf(matrix[i][j]) + " ");
            }
            builder.append("\n");
        }
        return builder.toString();
    }
}
