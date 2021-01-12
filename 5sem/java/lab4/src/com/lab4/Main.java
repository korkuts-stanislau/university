package com.lab4;

import com.lab4.loader.FileSparseMatrixLoader;
import com.lab4.matrix.Matrix;
import com.lab4.matrix.SparseMatrix;

import java.io.FileReader;
import java.io.Reader;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        try(Reader reader = new FileReader("C:\\Users\\stani\\OneDrive\\Cloud\\University\\5sem\\5semJAVA\\lab4\\src\\com\\lab4\\matrices.txt")) {
            List<Matrix> matrices = new FileSparseMatrixLoader().load(reader);
            try {
                System.out.println(matrices.get(0));
                System.out.println(matrices.get(1));
                Matrix sumMatrix = SparseMatrix.sum((SparseMatrix)matrices.get(0), (SparseMatrix)matrices.get(1));
                System.out.println(sumMatrix);
                Matrix prodMatrix = SparseMatrix.prod((SparseMatrix)matrices.get(0), (SparseMatrix)matrices.get(1));
                System.out.println(prodMatrix);
            }
            catch (Exception exception) {
                System.out.println(exception.getMessage());
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
