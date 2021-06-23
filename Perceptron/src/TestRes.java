public class TestRes {

    String name;
    double[] data;
    boolean status = true;

    public TestRes(String name, double[] data) {
        this.name = name;
        this.data = data;
    }

    @Override
    public String toString() {
        String tmp = "";
        for (int i = 0; i < data.length; i++) {
            tmp+=data[i]+" ";
        }
        return tmp+" " +" "+ status ;
    }
}
