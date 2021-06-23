import java.net.Socket;
import java.util.ArrayList;

public class Contest implements Runnable{

    Game p1;
    Game p2;
    boolean flag = true;
    boolean end = false;

    ArrayList<String> data = new ArrayList<>();

    public Contest(Socket p1, Socket p2) {
        this.p1 = new Game("x",this);
        this.p2 = new Game("o",this);
        for (int i = 0; i < 9; i++) {
            data.add("");
        }
    }

    @Override
    public void run() {
        p1.refersh();
        while (!end){
        }
        if(flag)
            p2.refersh();
        else p1.refersh();
    }

    void step(int index) {
        if (flag) {
            p2.change(index);
            data.set(index,"x");
            setEnd("x");
        } else {
            p1.change(index);
            data.set(index,"o");
            setEnd("o");
        }
        p1.refersh();
        p2.refersh();
        flag =!flag;
    }

    void setEnd(String s){
        end = check(s);
    }

    boolean check(String s){
        boolean res = false;
        for (int i = 0; i < 3; i++) {
            for (int j = i*3; j <= (i*3+2); j++) {
                if (data.get(j).equals(s))
                    res = true;
                else {
                    res = false;
                    break;}
            }
            if (res)
                return true;
        }
        for (int i = 0; i < 3; i++) {
            for (int j = i*3; j <= i+6; j+=3) {
                if (data.get(j).equals(s))
                    res = true;
                else {
                    res = false;
                    break;}
            }
            if (res)
                return true;
        }
        for (int i = 0; i < 9; i+=4) {
            if (data.get(i).equals(s))
                res = true;
            else {
                res = false;
                break;}
        }
        if (res)
            return true;
        for (int i = 2; i < 9; i+=2) {
            if (data.get(i).equals(s))
                res = true;
            else {
                res = false;
                break;}
        }
        if (res)
            return true;
        return false;
    }
}
