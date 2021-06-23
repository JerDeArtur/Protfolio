import java.util.ArrayList;
import java.util.List;

public class Cluster {

    ArrayList<Point> points = new ArrayList<>();
    Point centroid;
    String name;

    public Cluster(String name) {
        this.name = name;
    }

    public void setCentroid(){
        double[] resCoordinates = new double[points.get(0).coordinates.length];
        for (int i = 0; i < points.get(0).coordinates.length; i++) {
            double sum = 0;
            for (int j = 0; j < points.size(); j++)
                sum += points.get(j).coordinates[i];
            resCoordinates[i] = sum/points.size();
        }
        centroid = new Point(resCoordinates,name,this);
    }


    public double getWCV(){
        double res = 0;
        for (Point point : points)
            res += Point.getDistance(point,centroid);
        return res;
    }

    static boolean setNearestCluster(Point point,List<Cluster> clusters){
        Cluster nearest = clusters.get(0);
        for (int i = 1; i < clusters.size(); i++) {
            if(Point.getDistance(point,nearest.centroid) > Point.getDistance(point,clusters.get(i).centroid))
                nearest = clusters.get(i);
        }
        if(nearest != point.cluster){
            point.cluster.points.remove(point);
            point.cluster = nearest;
            nearest.points.add(point);
            return true;
        }else
            return false;
    }

    @Override
    public String toString() {
        return "Cluster{\n" +
                "name='" + name + "\'\n" +
                "WCV= "+getWCV()+'\n'+
                "centroid=" + centroid +
                "points\n" + points +
                "}\n\n";
    }
}
