public class Item {
    String name;
    String data;

    final static int a = 97;
    final static int z = 122;

    public Item(String name, String data) {
        this.name = name;
        this.data = data;
    }

    double[] getArray(){
        double[] res = new double[26];
        char[] arr = data.toCharArray();
        double len = 0;
        int counter = 0;
        for (int i = 0; i < arr.length; i++) {
            if(arr[i]>=a && arr[i]<=z) {
                res[arr[i] - a]++;
                counter++;
            }
        }
        for (int i = 0; i < res.length; i++) {
            res[i]/=counter;
            len += res[i]*res[i];
        }
        len = Math.sqrt(len);
        for (int i = 0; i < res.length; i++) {
            res[i]/=len;
        }

        return res;
    }

    @Override
    public String toString() {
        return "Item{" +
                "name='" + name + '\'' +
                ", data='" + data + '\'' +
                '}';
    }
}
