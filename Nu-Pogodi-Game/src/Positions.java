public enum Positions {
    TOP_LEFT(98.0,165.0,4),
    TOP_RIGHT(482.0,165.0,5),
    BOTTOM_LEFT(98.0,267.0,1),
    BOTTOM_RIGHT(482.0,267.0,2)
    ;


    private double w, h;
    private int c;
    Positions(double w, double h, int c) {
        this.w = w;
        this.h = h;
        this.c = c;
    }

    public int getC() {
        return c;
    }

    public double getW() {
        return w;
    }

    public double getH() {
        return h;
    }

    public static Positions random(){
        int a = (int) (Math.random()*4);
        switch (a){
            case 0:return TOP_LEFT;
            case 1:return TOP_RIGHT;
            case 2:return BOTTOM_LEFT;
            case 3:return BOTTOM_RIGHT;
        }
        return null;
    }
}
