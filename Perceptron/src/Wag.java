public class Wag {
    double[] wag;
    double t;
    double a;

    public Wag(double[] wag, double t, double a) {
        this.wag = wag;
        this.t = t;
        this.a = a;
    }

    @Override
    public String toString() {
        String tmp = "";
        for (int i = 0; i < wag.length; i++) {
            tmp+=wag[i]+" ";
        }
        return tmp +" "+t+" "+a;
    }
}
