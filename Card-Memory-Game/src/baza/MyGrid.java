package baza;

public class MyGrid {

    int x;
    int y;

    public MyGrid(int x, int y) {
        this.x = x;
        this.y = y;
    }

    @Override
    public String toString(){
        return x+"x"+y;
    }
}
