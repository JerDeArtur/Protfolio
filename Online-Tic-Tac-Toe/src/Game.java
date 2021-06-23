import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.stream.Collectors;

public class Game extends JFrame {

    JPanel panel = new JPanel();

    String cha;

    Contest server;

    boolean pause = false;

    ArrayList<JButton> data = new ArrayList<>();
    Game(String c,Contest server) {
        cha = c;
        this.server = server;
        panel.setLayout(new GridLayout(3,3));
        for (int i = 0; i < 9; i++) {
            JButton tmp = new JButton();
            data.add(tmp);
            tmp.setFont(new Font(null,Font.PLAIN,100));
            tmp.addActionListener(e->{
                tmp.setText(cha);
                server.step(data.indexOf(e.getSource()));
            });
            tmp.setEnabled(pause);
            tmp.setPreferredSize(new Dimension(100,100));
            panel.add(tmp);
        }

        add(panel);
        pack();
        setResizable(false);
        setLocationRelativeTo(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    void change(int index){
        data.get(index).setText(cha.equals("x")?"o":"x");
    }

    void refersh(){
        pause=!pause;
        for (JButton button : data)
            button.setEnabled(pause);
    }
}
