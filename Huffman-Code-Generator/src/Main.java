import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        try {
            Scanner scanner = new Scanner(new File(System.getProperty("user.dir")+"\\data.txt"));
            int n = Integer.parseInt(scanner.nextLine());

            Node root = null;

            ArrayList<Node> queue = new ArrayList<>();
            while(scanner.hasNextLine()){
                String[] tmp = scanner.nextLine().split(" ");
                put(new Node(tmp[0],Integer.parseInt(tmp[1])),queue);
            }
            Node tmp = null;
            System.out.println(queue);
            while(queue.size()>=2){
                Node n1 = queue.get(0);
                queue.remove(0);
                Node n2 = queue.get(0);
                queue.remove(0);
                tmp = new Node(n1.value+n2.value,n1.number+n2.number);
                put(tmp,queue);
                tmp.left = n1;
                tmp.right = n2;
                System.out.println(queue);
            }
            root = tmp;
            HashMap<String,String> res = new HashMap<>();
            char[] split = root.value.toCharArray();
            for (int i = 0; i < split.length; i++) {
                res.put(""+split[i],"");
            }
            for (String key : res.keySet()) {
                Node step = root;
                System.out.println(key + ": " +step + "----" + res.get(key));
                while(!step.value.equals(key)){
                    if(step.left.contains(key)) {
                        step = step.left;
                        res.replace(key,res.get(key)+0);
                    }else {
                        step = step.right;
                        res.replace(key,res.get(key)+1);
                    }
                    System.out.println(key + ": " +step + "----" + res.get(key));
                }
                System.out.println("|\n|\n|\n");
            }
            System.out.println("|\n|\n|\n"+res);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }

    public static void put(Node node, ArrayList<Node> queue){
        int i = 0;
        if(queue.isEmpty()){
            queue.add(node);
        }else {
            while ( queue.get(i).number < node.number) {
                i++;
                if(i > queue.size()-1)
                    break;
            }
            if (i > queue.size()-1)
                queue.add(node);
            else
                queue.add(i, node);
        }
    }
}
