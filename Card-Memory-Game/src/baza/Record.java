package baza;

import java.time.LocalTime;

public class Record {
    private String player;
    private LocalTime time;
    private MyGrid grid;

    Record(String player, LocalTime time, MyGrid grid) {
        this.player = player;
        this.time = time;
        this.grid = grid;
    }

    @Override
    public String toString() {
        return player+" (Time: "+time.toString()+", "+grid.toString()+')'+'\n';
    }
}
