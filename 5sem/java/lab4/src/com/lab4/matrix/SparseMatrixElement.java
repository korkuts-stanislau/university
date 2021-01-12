package com.lab4.matrix;

public class SparseMatrixElement {
    int rowIndex;
    int columnIndex;
    double value;

    public SparseMatrixElement(int rowIndex, int columnIndex, double value) {
        this.rowIndex = rowIndex;
        this.columnIndex = columnIndex;
        this.value = value;
    }

    public static SparseMatrixElement add(SparseMatrixElement firstElement, SparseMatrixElement secondElement) throws Exception {
        if(firstElement.rowIndex == secondElement.rowIndex && firstElement.columnIndex == secondElement.columnIndex) {
            return new SparseMatrixElement(firstElement.rowIndex, firstElement.columnIndex, firstElement.value + secondElement.value);
        }
        else
            throw new Exception("Эти элементы находятся не на одинаковых позициях");
    }
}
