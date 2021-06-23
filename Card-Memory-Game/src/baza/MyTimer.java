package baza;

import javax.swing.*;
import java.awt.*;
import java.time.LocalTime;

class MyTimer extends JLabel{

    private LocalTime time;
    private boolean flag = true;
    TimerThread tmp = new TimerThread(this);

    MyTimer(){
        setPreferredSize(new Dimension(100,100));
        setAlignmentX(Component.CENTER_ALIGNMENT);
        setFont(new Font("gg",Font.BOLD,18));
        time = LocalTime.MIN;
        setText(time.getMinute()+":"+time.getSecond());
    }

    void start(){
        tmp.start();
    }

    void stop(){
        tmp.flag = false;
    }

    LocalTime getTime() {
        return time;
    }

    void setTime(LocalTime time) {
        this.time = time;
    }
}
