import java.util.ArrayList;
import java.util.HashMap;

public class Point {

    String word = "X";

    static HashMap<String,String> rules = new HashMap<>();

    double x;
    double y;
    int angle;
    static ArrayList<Point> stos = new ArrayList<>();


    public Point(double x, double y, int angle) {
        this.x = x;
        this.y = y;
        this.angle = angle;
    }

    Point change(double x, double y, int angle){
        this.x = x;
        this.y = y;
        this.angle = angle;
        return this;
    }

    Point add(){
        stos.add(new Point(x,y,angle));
        return this;
    }

    Point get(){
        Point tmp = stos.get(stos.size()-1);
        stos.remove(stos.size()-1);
        return tmp;
    }

    Point step(){
        x+=Math.cos(Math.toRadians(angle));
        y+=Math.sin(Math.toRadians(angle));
        return this;
    }

    Point iterate(int iterations){
        for (int i = 0; i < iterations; i++) {
            for (String key : rules.keySet())
                word = word.replace(key, rules.get(key));
        }
        return this;
    }
}
