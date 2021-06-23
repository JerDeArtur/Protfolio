import java.util.List;

public class InputWag {

    String language;
    double[] vektor = new double[26];
    double t;
    double alfa;

    public InputWag(String language, double t, double alfa) {
        this.language = language;
        this.t = t;
        this.alfa = alfa;
    }

    double check(Item item){
        double net = 0;
        double[] arr = item.getArray();
        System.out.println(language);
        for (int i = 0; i < vektor.length; i++) {
            net += Math.pow(vektor[i]-arr[i],2);
        }
        return  net/2;
    }

    @Override
    public int hashCode() {
        return language.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        return ((InputWag)obj).language.equals(language);
    }

    void train(List<Item> list){
        double net;
        for (int j = 0; j < 5; j++) {
            for (Item item : list) {
                net = 0;
                double[] arr = item.getArray();
                for (int i = 0; i < vektor.length; i++) {
                    net += arr[i] * vektor[i];
                }
                if(((net - t) > 0) && !item.name.equals(language)){
                    for (int i = 0; i < vektor.length; i++) {
                        vektor[i]-=arr[i]*alfa;
                    }
                    t+=alfa;
                }else if(((net - t) <= 0) && language.equals(item.name)){
                    for (int i = 0; i < vektor.length; i++) {
                        vektor[i]+=arr[i]*alfa;
                    }
                    t-=alfa;
                }
            }
        }
        double len = 0;
        for (int i = 0; i < vektor.length; i++) {
            len += vektor[i]*vektor[i];
        }
        len = Math.sqrt(len);
        for (int i = 0; i < vektor.length; i++) {
            vektor[i]/=len;
        }
    }
}