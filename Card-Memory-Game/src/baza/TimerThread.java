package baza;

public class TimerThread extends Thread {


    boolean flag = true;
    private MyTimer timer;

    TimerThread(MyTimer timer){
        this.timer = timer;
    }

    @Override
    public void run() {
        while(flag) {
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            timer.setTime(timer.getTime().plusSeconds(1));
            timer.setText(timer.getTime().getMinute() + ":" + timer.getTime().getSecond());
        }
    }
}
