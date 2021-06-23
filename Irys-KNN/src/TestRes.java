/*
    Represents test object and correctness of it's classification
*/
public class TestRes {

    String name;
    String data;
    boolean status = true;

    public TestRes(String name, String data) {
        this.name = name;
        this.data = data;
    }

    @Override
    public String toString() {
        return data + status ;
    }
}
