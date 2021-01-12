package com.lab4.loader;

import com.lab4.loader.FileMatrixLoader;
import com.lab4.matrix.Matrix;
import com.lab4.matrix.SparseMatrix;
import com.lab4.matrix.SparseMatrixElement;

import java.io.Reader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class FileSparseMatrixLoader extends FileMatrixLoader {
    @Override
    public List<Matrix> load(Reader reader) throws Exception{
        String text = getRowTextFromFile(reader);
        return getMatricesFromText(text);
    }

    private String getRowTextFromFile(Reader reader) throws Exception {
        StringBuilder builder = new StringBuilder();
        int c;
        while((c = reader.read()) != -1) {
            builder.append((char)c);
        }
        return builder.toString();
    }

    private List<Matrix> getMatricesFromText(String text) throws Exception {
        Pattern pattern = Pattern.compile("\\s*Matrix (\\s*\\w+\\s*)+\\s*" +
                                          "\\s*Size \\s*\\d+x\\d+\\s*" +
                                          "\\s*Values\\s*" +
                                          "(\\s*(\\((\\s*-?(\\d+(\\.?\\d+)?)\\s*),(\\s*-?(\\d+(\\.?\\d+)?)\\s*),(\\s*-?(\\d+(\\.?\\d+)?)\\s*)\\))\\s*)*");
        Matcher matcher = pattern.matcher(text);
        List<Matrix> matrices = new ArrayList<>();
        while(matcher.find()) {
            matrices.add(getMatrixFromText(matcher.group()));
        }
        return matrices;
    }

    private Matrix getMatrixFromText(String text) throws Exception {
        String[] lines = text.split("(\\r\\n)+");
        String name = String.join(" ", Arrays.copyOfRange(lines[0].split("\\s+"), 1, lines[0].split("\\s+").length));
        String[] sizes = lines[1].split("\\s+")[1].split("\\s*x\\s*");
        int rows, columns;
        try {
            rows = Integer.parseInt(sizes[0]);
            columns = Integer.parseInt(sizes[1]);
        }
        catch (Exception exception){
            throw new Exception("Неправильное описание размера матрицы в файле");
        }
        List<SparseMatrixElement> elements = new ArrayList<>();
        for(int i = 3; i < lines.length; i++) {
            String numbersString = lines[i].replaceAll("\\s*\\(\\s*", "").replaceAll("\\s*\\)\\s*", "");
            String[] numbers = numbersString.split("\\s*,\\s*");
            elements.add(new SparseMatrixElement(Integer.parseInt(numbers[0]), Integer.parseInt(numbers[1]), Double.parseDouble(numbers[2])));
        }
        return new SparseMatrix(name, rows, columns, elements);
    }
}
