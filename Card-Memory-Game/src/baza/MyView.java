package baza;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;

class MyView {

    Controller controller;

    JFrame frame = new JFrame();

    JPanel panel = new JPanel();

    MyGrid grid;

    boolean flag;

    MyView(Controller controller){
        frame.getRootPane().getInputMap(JComponent.WHEN_IN_FOCUSED_WINDOW).put(KeyStroke.getKeyStroke("ctrl Q"),"exit");
        frame.getRootPane().getActionMap().put("exit", new AbstractAction() {
            @Override
            public void actionPerformed(ActionEvent e) {
                controller.start();
            }
        });
        frame.add(panel);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.controller = controller;
    }

    void startPanel(){
        panel.removeAll();
        SwingUtilities.invokeLater(()-> {
            JLabel nazwa = new JLabel("Memory The game");
            nazwa.setFont(new Font("gg",Font.BOLD,16));
            nazwa.setAlignmentX(Component.CENTER_ALIGNMENT);

            JLabel ska = new JLabel();
            ska.setAlignmentX(Component.CENTER_ALIGNMENT);
            if(!flag) {
                ska.setText("s18486");
                ska.addMouseListener(new Cos(controller));
            }else ska.setIcon(new ImageIcon(new ImageIcon("Z:\\GUI\\Project2\\test\\TrollFace.jpg").getImage().getScaledInstance(100,100,Image.SCALE_SMOOTH)));

            JButton newG = new JButton("New Game");
            newG.addActionListener((e) -> {
                controller.gameStart();
            });
            newG.setMaximumSize(new Dimension(150,50));
            newG.setMinimumSize(new Dimension(150,50));
            newG.setAlignmentX(Component.CENTER_ALIGNMENT);

            JButton scores = new JButton("Hihg Scores");
            scores.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    panel.removeAll();
                    panel.setLayout(new BoxLayout(panel,BoxLayout.Y_AXIS));

                    ScrollPane scrollPane = new ScrollPane();
                    JList list = new JList<>(new MyJListModel(controller.model.scores));
                    scrollPane.add(list);
                    scrollPane.setPreferredSize(new Dimension(300,100));
                    panel.add(scrollPane);
                    panel.add(Box.createRigidArea(new Dimension(0,20)));
                    JButton button = new JButton("Close");
                    button.addActionListener((event)->{
                        controller.start();
                    });
                    button.setPreferredSize(new Dimension(100,30));
                    button.setAlignmentX(Component.CENTER_ALIGNMENT);
                    panel.add(button);

                    frame.repaint();
                    frame.pack();
                    frame.setLocationRelativeTo(null);
                    frame.setVisible(true);
                }
            });
            scores.setMaximumSize(new Dimension(150,40));
            scores.setMinimumSize(new Dimension(150,40));
            scores.setAlignmentX(Component.CENTER_ALIGNMENT);

            JButton exit = new JButton("Exit");
            exit.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    System.exit(0);
                }
            });
            exit.setMaximumSize(new Dimension(150,40));
            exit.setMinimumSize(new Dimension(150,40));
            exit.setAlignmentX(Component.CENTER_ALIGNMENT);

            panel.setLayout(new BoxLayout(panel,BoxLayout.Y_AXIS));
            panel.add(nazwa);
            panel.add(Box.createRigidArea(new Dimension(0,20)));
            panel.add(ska);
            panel.add(Box.createRigidArea(new Dimension(0,30)));
            panel.add(newG);
            panel.add(Box.createRigidArea(new Dimension(0,10)));
            panel.add(scores);
            panel.add(Box.createRigidArea(new Dimension(0,10)));
            panel.add(exit);

            frame.repaint();
            frame.pack();
            frame.setLocationRelativeTo(null);
            frame.setVisible(true);
        });
    }

    void drawComponents(ArrayList<Card> cards,MyGrid grid){
        this.grid = grid;
        panel.setLayout(new BoxLayout(panel,BoxLayout.Y_AXIS));
        controller.timer = new MyTimer();
        panel.add(controller.timer);

        JPanel foreground = new JPanel();
        GridLayout gridLayout = new GridLayout(grid.x,grid.y);
        gridLayout.preferredLayoutSize(panel);
        gridLayout.setHgap(20);
        gridLayout.setVgap(20);
        foreground.setLayout(gridLayout);
        for(Card card : cards) {
            MyJButton tmp = new MyJButton(card,controller);
            tmp.setIcon(card.getBack());
            tmp.setPreferredSize(new Dimension(100,100));
            foreground.add(tmp);
        }
        panel.add(foreground);

        frame.pack();
        frame.repaint();
        SwingUtilities.invokeLater(controller.timer::start);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
