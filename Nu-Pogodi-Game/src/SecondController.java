import javafx.animation.RotateTransition;
import javafx.animation.TranslateTransition;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.AnchorPane;
import javafx.util.Duration;

import java.io.IOException;
import java.util.ArrayList;

public class SecondController {
    @FXML
    private Label health;
    private int counter = 4;
    @FXML
    private Label score;
    static int counter2 = 0;
    @FXML
    private AnchorPane root;
    @FXML
    private ImageView basket1;
    @FXML
    private ImageView basket2;
    @FXML
    private ImageView basket4;
    @FXML
    private ImageView basket5;

    private int current = 2;

    private ArrayList<ImageView> views = new ArrayList<>();

    private boolean myflag = true;


    @FXML
    private void initialize(){
        views.add(basket1);
        views.add(basket2);
        views.add(basket4);
        views.add(basket5);
        Thread thread = new Thread(){
            boolean flag = false;

            @Override
            public void run() {
                try {
                    Thread.sleep(10);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                flag = true;
                while (flag) {
                    try {
                        Thread.sleep((long) (2000));
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    Positions tmp = Positions.random();
                    ImageView test = new ImageView("testpng/thanos.png");
                    test.setFitHeight(20);
                    test.setFitWidth(20);
                    test.setLayoutX(tmp.getW());
                    test.setLayoutY(tmp.getH());

                    RotateTransition realrotate = new RotateTransition(Duration.seconds(4),test);

                    TranslateTransition rotate = new TranslateTransition(Duration.seconds(4),test);

                    rotate.setFromX(0);
                    rotate.setFromY(0);
                    rotate.setToY(25);
                    if(tmp.getC() == 4 || tmp.getC() == 1) {
                        realrotate.setToAngle(540);
                        rotate.setToX(100);
                    }else {
                        realrotate.setToAngle(-540);
                        rotate.setToX(-100);
                    }
                    rotate.setOnFinished(event -> {
                        if(myflag) {
                            if (current == tmp.getC()) {
                                score.setText("Eggs:" + (++counter2));
                                root.getChildren().remove(((TranslateTransition) event.getSource()).getNode());
                            } else {
                                counter--;
                                if (counter == 0) {
                                    flag = false;
                                    myflag = false;
                                    try {
                                        root.getScene().setRoot(FXMLLoader.load(getClass().getResource("Scores.fxml")));
                                    } catch (IOException e) {
                                        e.printStackTrace();
                                    }
                                } else {
                                    health.setText("Health: " + counter);
                                    root.getChildren().remove(((TranslateTransition) event.getSource()).getNode());
                                }
                            }
                        }
                    });
                    Platform.runLater(()->{
                        root.getChildren().add(test);
                        rotate.play();
                        realrotate.play();
                    });
                }
            }
        };
        thread.start();
    }

    public void press(KeyEvent event){
        switch (event.getCode()){
            case NUMPAD1:
                for (ImageView view : views) {
                    view.setVisible(false);
                }
                basket1.setVisible(true);
                current = 1;
                break;
            case NUMPAD2:
                for (ImageView view : views) {
                    view.setVisible(false);
                }
                basket2.setVisible(true);
                current = 2;
                break;
            case NUMPAD4:
                for (ImageView view : views) {
                    view.setVisible(false);
                }
                basket4.setVisible(true);
                current = 4;
                break;
            case NUMPAD5:
                for (ImageView view : views) {
                    view.setVisible(false);
                }
                basket5.setVisible(true);
                current = 5;
                break;
        }
    }
}
