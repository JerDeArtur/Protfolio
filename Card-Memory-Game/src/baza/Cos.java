package baza;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

public class Cos implements MouseListener {

    Controller controller;

    Cos(Controller controller){
        this.controller = controller;
    }

    @Override
    public void mouseClicked(MouseEvent e) {
        controller.view.panel.removeAll();
        SwingUtilities.invokeLater(() -> {
            JButton tmp = new JButton();
            ImageIcon ricardo = new ImageIcon("Z:\\GUI\\Project2\\test\\funko-pop-russia-ricardo-milos.jpg");
            ImageIcon icon = new ImageIcon("Z:\\GUI\\Project2\\test\\photo_2019-05-22_20-13-21.jpg");
            tmp.addActionListener((event) -> {
                JButton tmp1 = new JButton();
                tmp1.addActionListener((es) -> {
                    controller.start();
                    controller.view.flag = true;
                });
                if (tmp.getIcon() == ricardo) {
                    controller.view.panel.removeAll();
                    SwingUtilities.invokeLater(() -> {
                        tmp.setIcon(icon);
                        tmp.setPreferredSize(new Dimension(tmp.getIcon().getIconWidth(), tmp.getIcon().getIconHeight()));
                        controller.view.panel.add(tmp);
                        controller.view.frame.pack();
                        controller.view.panel.add(tmp1);
                        controller.view.frame.repaint();
                        controller.view.frame.setLocationRelativeTo(null);
                        controller.view.frame.setVisible(true);
                    });
                } else {
                    controller.view.panel.removeAll();
                    SwingUtilities.invokeLater(() -> {
                        tmp.setIcon(ricardo);
                        tmp.setPreferredSize(new Dimension(tmp.getIcon().getIconWidth(), tmp.getIcon().getIconHeight()));
                        controller.view.panel.add(tmp);
                        controller.view.frame.pack();
                        controller.view.frame.repaint();
                        controller.view.frame.setLocationRelativeTo(null);
                        controller.view.frame.setVisible(true);
                    });
                }
            });
            tmp.setIcon(ricardo);
            tmp.setPreferredSize(new Dimension(tmp.getIcon().getIconWidth(), tmp.getIcon().getIconHeight()));
            controller.view.panel.add(tmp);
            controller.view.frame.pack();
            controller.view.frame.repaint();
            controller.view.frame.setLocationRelativeTo(null);
            controller.view.frame.setVisible(true);
        });
    }

    @Override
    public void mousePressed(MouseEvent e) {

    }

    @Override
    public void mouseReleased(MouseEvent e) {

    }

    @Override
    public void mouseEntered(MouseEvent e) {

    }

    @Override
    public void mouseExited(MouseEvent e) {

    }
}
