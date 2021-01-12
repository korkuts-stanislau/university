package com.lab4.loader;

import com.lab4.matrix.Matrix;

import java.io.Reader;
import java.util.List;

public abstract class FileMatrixLoader {
    public abstract List<Matrix> load(Reader reader) throws Exception;
}
