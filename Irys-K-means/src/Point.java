import java.util.Arrays;

public class Point {

    double[] coordinates;
    String realName;
    Cluster cluster;

    public Point(String coordinates, String name, Cluster cluster) {
        String[] arr = coordinates.split(" ");
        this.coordinates = new double[arr.length];
        for (int i = 0; i < arr.length; i++) {
            this.coordinates[i] = Double.parseDouble(arr[i]);
        }
        this.realName = name;
        this.cluster = cluster;
    }

    public Point(double[] coordinates, String realName, Cluster cluster) {
        this.coordinates = coordinates;
        this.realName = realName;
        this.cluster = cluster;
    }

    static double getDistance(Point point1, Point point2){
        double res = 0;
        for (int i = 0; i < point1.coordinates.length; i++) {
            res += Math.pow(point1.coordinates[i]-point2.coordinates[i],2);
        }
        return res;
    }

    @Override
    public String toString() {
        return '\t'+Arrays.toString(coordinates)+" "+realName+"\n";
    }
}
