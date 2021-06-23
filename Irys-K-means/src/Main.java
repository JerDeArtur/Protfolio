import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        ArrayList<Cluster> clusters = new ArrayList<>();

        for (int i = 0; i < Integer.parseInt(args[1]); i++) {
            clusters.add(new Cluster("Group "+i));
        }

        try {
            ArrayList<Point> points = readTest(args[0],clusters);
            Collections.shuffle(points);
            for (Point point : points) {
                point.cluster.points.add(point);
            }
            int itteration = 1;
            int changed = 1;
            while(changed != 0) {
                for (Cluster cluster : clusters) {
                    cluster.setCentroid();
                }
                changed = 0;
                for (Point point : points) {
                    if(Cluster.setNearestCluster(point, clusters))
                        changed++;
                }
                if(args[2].equals("true")) {
                    double corrrect = 0;
                    double wrong = 0;
                    for (Cluster cluster : clusters) {
                        HashMap<String, Integer> set = new HashMap<>();
                        for (Point point : cluster.points) {
                            if (!set.containsKey(point.realName))
                                set.put(point.realName, 1);
                            else
                                set.replace(point.realName, set.get(point.realName) + 1);
                        }
                        String max = "";
                        for (String key : set.keySet()) {
                            if (max.isEmpty())
                                max = key;
                            if (set.get(max) < set.get(key))
                                max = key;
                        }
                        for (String key : set.keySet()) {
                            if (key.equals(max))
                                corrrect += set.get(key);
                            else
                                wrong += set.get(key);
                        }
                    }
                    double res = 0;
                    for (Cluster c : clusters) {
                        res += c.getWCV();
                    }
                    System.out.println(itteration++);
                    System.out.println("WCV "+res);
                    System.out.println("Wrong " + (wrong / (wrong + corrrect)));
                    System.out.println("|");
                }
            }
            System.out.println(clusters);

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }

    static ArrayList<Point> readTest(String path,List<Cluster> clusters) throws FileNotFoundException {
        Scanner scanner = new Scanner(new File(path));
        ArrayList<Point> data = new ArrayList<>();
        String[] tmp;
        while (scanner.hasNextLine()) {
            tmp = scanner.nextLine().split(",");
            String st="";
            for (int i = 0; i < tmp.length-1; i++) {
                st+=tmp[i]+" ";
            }
            data.add(new Point(
                    st,tmp[tmp.length-1],clusters.get((int)(Math.random()*clusters.size()))
            ));
        }
        return  data;
    }
}