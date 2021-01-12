package com.lab5.figure;

import java.util.List;

public abstract class Point {
    private double[] coordsVector;

    protected Point(double[] coordsVector) {
        this.coordsVector = coordsVector;
    }

    public double getDistanceFrom(Point point) throws Exception {
        if(point.coordsVector.length != this.coordsVector.length)
            throw new Exception("Эти точки находятся в разных пространствах");
        double accum = 0;
        for(int i = 0; i < this.coordsVector.length; i++) {
            accum += Math.pow((this.coordsVector[i] - point.coordsVector[i]), 2);
        }
        return Math.sqrt(accum);
    }

    public double[] getCoordinatesVector() {
        return coordsVector;
    }
}
