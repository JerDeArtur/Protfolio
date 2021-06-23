public class Node {

    Node left = null;
    Node right = null;

    String value;
    int number;

    public Node(String value,int number) {
        this.value = value;
        this.number = number;
    }

    public boolean contains(String s){
        return value.contains(s);
    }

    @Override
    public String toString() {
        return value + ' ' +number+"()";
    }
}
