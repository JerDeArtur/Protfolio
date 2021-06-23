import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.chart.NumberAxis;
import javafx.scene.chart.ScatterChart;
import javafx.scene.chart.XYChart;
import javafx.scene.layout.Region;
import javafx.scene.shape.Circle;
import javafx.stage.Stage;

import java.io.File;
import java.util.HashMap;
import java.util.function.Function;

public class Main extends Application {

    static HashMap<Character, Function<Point,Point>> methods = new HashMap<>();

    XYChart.Series<Number,Number> data = new XYChart.Series<>();


    @Override
    public void start(Stage primaryStage) throws Exception {
        Point point = new Point(0,0,25);
        point.iterate(Integer.parseInt(getParameters().getRaw().get(0)));

        final NumberAxis xAxis = new NumberAxis();
        final NumberAxis yAxis = new NumberAxis();
        final ScatterChart<Number, Number> chart = new ScatterChart<>(xAxis,yAxis);
        chart.setId("bifurcation-diagram");


        calc(point);

        System.out.println("calced");

        chart.getData().add(data);
        chart.setPrefSize(700,600);

        Scene scene = new Scene(chart);
        scene.getStylesheets().add(new File(System.getProperty("user.dir")+"\\bifurcation.css").toURI().toURL().toString());
        primaryStage.setScene(scene);
        primaryStage.setResizable(false);

        primaryStage.show();
    }

    public static void main(String[] args) {
        Point.rules.put("X","F+[[X]-X]-F[-FX]+X");
        Point.rules.put("F","FF");

        Main.methods.put('+',e->e.change(e.x,e.y,e.angle+25));
        Main.methods.put('-',e->e.change(e.x,e.y,e.angle-25));
        Main.methods.put('[', Point::add);
        Main.methods.put(']', Point::get);
        Main.methods.put('F', Point::step);
        Main.methods.put('X',e->e);
        launch(args);
    }

    void calc(Point point){
        Point last = new Point(point.x,point.y,point.angle);
        Point next;
        char[] word = point.word.toCharArray();
        for (int i = 0; i < word.length; i++) {
            System.out.println(i);
            next = methods.get(word[i]).apply(last);

            System.out.println(next.x+"()"+next.y);

            XYChart.Data<Number,Number> tmp= new XYChart.Data<>(next.x,next.y);
            Region plotpoint = new Region();
            plotpoint.setShape(new Circle(0.5));
            tmp.setNode(plotpoint);
            data.getData().add(tmp);

            last = new Point(next.x,next.y,next.angle);
        }
    }
}
