import java.util.ArrayList;

public class Node {
    int x;
    int y;
    boolean checked = false;
    ArrayList<Node> connected = new ArrayList<>();

    public Node(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public static ArrayList<Node> connect(Node[][] data){
        ArrayList<Node> res = new ArrayList<>();
        for (int i = 0; i <data.length ; i++) {
            for (int j = 0; j < data[i].length; j++) {
                if(data[i][j] != null){
                    connect2(data,i,j);
                    res.add(data[i][j]);
                }
            }
        }
        return res;
    }

    private static void connect2(Node[][] data,int x,int y){
        int on = x;
        int under = x;
        int left = y;
        int right = y;
        if(x-1>=0) {
            on = x - 1;
        }
        if(x+1<data.length) {
            under = x + 1;
        }
        if(y-1>=0) {
            left = y - 1;
        }
        if(y+1<data[x].length) {
            right = y + 1;
        }
        for (int i = on; i <= under; i++) {
            for (int j = left; j <= right; j++) {
                if(!(i==x && j==y) && data[i][j]!=null) {
                    data[x][y].connected.add(data[i][j]);
                }
            }
        }
    }

    @Override
    public String toString() {
        return "Node{" +
                "x=" + x +
                ", y=" + y +
                '}';
    }
}
