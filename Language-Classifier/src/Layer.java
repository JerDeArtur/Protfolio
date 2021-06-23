import java.util.List;
import java.util.Set;

public class Layer {

    Set<InputWag> vektors;
    double edge;

    public Layer(Set<InputWag> vektors, List<Item> train) {
        this.vektors = vektors;
        for (InputWag wag : vektors) {
            wag.train(train);
        }
    }

    String getResult(Item item){
        double tmp = 0;
        InputWag res = null;
        for (InputWag vektor : vektors) {
            if(res == null) {
                tmp = vektor.check(item);
                System.out.println(tmp);
                res = vektor;
            }else {
                double a = vektor.check(item);
                System.out.println(a);
                if(a < tmp){
                    tmp = a;
                    res = vektor;
                }
            }
        }
        return res.language;
    }
}
