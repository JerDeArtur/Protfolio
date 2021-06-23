import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Scanner;

public class Main {
    public static int Counter = 0;

    public static void main(String[] args) {
        try {
            Scanner scanner = new Scanner(new File("Z:\\ASD3\\src\\test.txt"));
            int y = scanner.nextInt();
            int x = scanner.nextInt();
            Node[][] data = new Node[x][y];
            for (int i = 0; i < data.length; i++) {
                for (int j = 0; j < data[i].length; j++) {
                    data[i][j] = scanner.nextInt() == 0?null:new Node(i,j);
                }
            }
            ArrayList<Node> graph = Node.connect(data);
            int res = 0;
            for (Node s: graph) {
                if(!s.checked) {
                    LinkedList<Node> queue = new LinkedList<>();
                    s.checked = true;
                    queue.add(s);
                    while (queue.size() != 0) {
                        s = queue.poll();
                        for (Node n : s.connected) {
                            if (!n.checked) {
                                n.checked = true;
                                queue.add(n);
                            }
                        }
                    }
                    res++;
                }
            }
            System.out.println(res);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

    }
}
