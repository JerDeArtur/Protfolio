package baza;

public class MyThread extends  Thread {

    boolean flag = true;

    @Override
    public void run() {
        flag = false;
        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        ((MyJButton) Controller.first.conteiner).setIcon(Controller.first.getBack());
        ((MyJButton) Controller.second.conteiner).setIcon(Controller.second.getBack());
        Controller.first = null;
        Controller.second = null;
        flag = true;
    }

}
