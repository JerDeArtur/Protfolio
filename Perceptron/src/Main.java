import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;

public class Main {
    static  Wag wag;
    public static void main(String[] args) {
        try {
            String[] types = new String[2];
            List<TestRes> data = read(System.getProperty("user.dir")+"\\"+args[0]);
            wag=new Wag(new double[data.get(0).data.length],3,Double.parseDouble(args[2]));
            types[0] = data.get(0).name;
            int s = 1;
            for (TestRes row: data) {
                if(!row.name.equals(types[0])&&!row.name.equals(types[1])) {
                    types[s] = row.name;
                    s++;
                }
            }
            train(data,types);
            List<TestRes> testData = read(System.getProperty("user.dir")+"\\"+args[1]);
            HashMap<String, List<TestRes>> test = test(testData,types);
            double counter = 0;
            double total = 0;
            for (String type:test.keySet()) {
                total += test.get(type).size();
                System.out.println(type);
                for (int e = 0; e < test.get(type).size(); e++) {
                    TestRes tmp = test.get(type).get(e);
                    System.out.println(tmp);
                    if(!tmp.status)
                        counter++;
                }
                System.out.println();
                System.out.println();
            }
            System.out.println(counter/total*100+"% are chosen wrongly");
            System.out.println("Input pattern is vector data and k (everything should be separated by space)");
            System.out.println("Print \"exit\" to close this application");
            Scanner scanner = new Scanner(System.in);
            String tmp = scanner.nextLine();
            while(!tmp.equals("exit")){
                String[] arrSt = tmp.split(" ");
                ArrayList<TestRes> tmpList = new ArrayList<>();
                double[] arr = new double[arrSt.length];
                for (int i = 0; i < arrSt.length-1; i++) {
                    arr[i] = Double.parseDouble(arrSt[i]);
                }
                tmpList.add(new TestRes("",arr));
                try {
                    HashMap<String,List<TestRes>> answer = test(tmpList,types);
                    System.out.println("|");
                    System.out.println("|");
                    for (String type:answer.keySet()) {
                        System.out.println(type);
                        for (int i = 0; i < answer.get(type).size(); i++) {
                            TestRes tmp2 = answer.get(type).get(i);
                            for (int j = 0; j < tmp2.data.length; j++) {
                                System.out.print(tmp2.data[i]+' ');
                            }
                        }
                        System.out.println("|");
                        System.out.println("|");
                    }
                }catch (Exception e){
                    e.printStackTrace();
                }
                System.out.println("Input pattern is vector data and k (everything should be separated by space)");
                System.out.println("Print \"exit\" to close application");
                tmp = scanner.nextLine();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }

    private static void train(List<TestRes> data, String[] types){
        for(TestRes row : data){
                double net = 0;
                for (int i = 0; i < row.data.length; i++) {
                    net+=wag.wag[i]*row.data[i];
                }
                double d = row.name.equals(types[0]) ? 0 : 1;
                double y = net > wag.t ? 1 : 0;
                if(d != y){
                    double con = (d-y)*wag.a;
                    double[] newWag = new double[wag.wag.length];
                    for (int i = 0; i < newWag.length; i++) {
                        newWag[i] = wag.wag[i]+con*row.data[i];
                    }
                    wag.wag = newWag;
                    wag.t = wag.t - con;
                }
        }
    }

    private static HashMap<String, List<TestRes>> test(List<TestRes> test,String[] types){
        HashMap<String, List<TestRes>> res = new HashMap<>();
        for (String type : types) {
            res.put(type, new ArrayList<>());
        }
        for (TestRes row:test) {
            double net = 0;
            for (int i = 0; i < row.data.length; i++) {
                net+=wag.wag[i]*row.data[i];
            }
            double y = net > wag.t ? 1 : 0;
            row.status = row.name.equals(types[(int)y]);
            res.get(types[(int)y]).add(row);
        }
        return res;
    }

    private static List<TestRes> read(String path) throws FileNotFoundException {
        Scanner scanner = new Scanner(new File(path));
        ArrayList<TestRes> data = new ArrayList<>();
        String[] tmp;
        while (scanner.hasNextLine()) {
            tmp = scanner.nextLine().split(",");
            double[] arr = new double[tmp.length-1];
            for (int i = 0; i < tmp.length-1; i++) {
                arr[i] = Double.parseDouble(tmp[i]);
            }
            data.add(new TestRes(tmp[tmp.length-1],arr));
        }
        return  data;
    }
}
