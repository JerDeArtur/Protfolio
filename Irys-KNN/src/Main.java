import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        try {
            HashMap<String,List<String>> data = read(System.getProperty("user.dir")+"\\"+args[0]);
            List<TestRes> testData = readTest(System.getProperty("user.dir")+"\\"+args[1]);
            HashMap<String, List<TestRes>> test = test(data,testData,Integer.parseInt(args[2]));
            double counter = 0;
            double total = 0;
            for (String type:test.keySet()) {
                total += test.get(type).size();
                System.out.println(type);
                for (int i = 0; i < test.get(type).size(); i++) {
                    TestRes tmp = test.get(type).get(i);
                    System.out.println(tmp);
                    if(!tmp.status)
                        counter++;
                }
                System.out.println();
                System.out.println();
            }
            System.out.println(counter/total*100+"% are chosen wrongly");
            System.out.println("Input pattern is vector data and k (everything should be separated by space)");
            System.out.println("Print \"exit\" to close application");
            Scanner scanner = new Scanner(System.in);
            String tmp = scanner.nextLine();
            while(!tmp.equals("exit")){
                String[] arr = tmp.split(" ");
                ArrayList<TestRes> tmpList = new ArrayList<>();
                String st="";
                for (int i = 0; i < arr.length-1; i++) {
                    st+=arr[i]+" ";
                }
                tmpList.add(new TestRes("",st));
                try {
                    HashMap<String,List<TestRes>> answer = test(data,tmpList,Integer.parseInt(arr[arr.length-1]));
                    System.out.println("|");
                    System.out.println("|");
                    for (String type:answer.keySet()) {
                        System.out.println(type);
                        for (int i = 0; i < answer.get(type).size(); i++) {
                            TestRes tmp2 = answer.get(type).get(i);
                            System.out.println(tmp2.data);
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

    static double calcSquareLength(String p1, String p2){
        double res = 0;
        String[] tmp1 = p1.split(" ");
        String[] tmp2 = p2.split(" ");
        for (int i = 0; i < tmp1.length; i++) {
            res+=Math.pow(Double.parseDouble(tmp1[i])-Double.parseDouble(tmp2[i]),2);
        }
        return res;
    }

    static HashMap<String, List<TestRes>> test(HashMap<String, List<String>> data,List<TestRes> test,int k){
        HashMap<String, List<TestRes>> res = new HashMap<>();
        for (TestRes row:test) {
            ArrayList<TmpRes> tmpList = new ArrayList<>();
            for(String type:data.keySet()){
                for (String point:data.get(type)) {
                    tmpList.add(new TmpRes(type,calcSquareLength(row.data,point)));
                }
            }
            HashMap<String,Integer> tmpMap = new HashMap<>();
            for (int i = 0; i < k; i++) {
                TmpRes tmpRes = getSmallest(tmpList);
                if(!tmpMap.keySet().contains(tmpRes.type))
                    tmpMap.put(tmpRes.type,1);
                else
                    tmpMap.replace(tmpRes.type,tmpMap.get(tmpRes.type)+1);
            }
            String result ="";
            for (String type:tmpMap.keySet()) {
                if(result.isEmpty())
                    result = type;
                else if(tmpMap.get(result)<tmpMap.get(type))
                    result = type;
            }
            if(!res.containsKey(result))
                res.put(result, new ArrayList<>());
            row.status = row.name.equals(result);
            res.get(result).add(row);
        }
        return res;
    }

    static HashMap<String, List<String>> read(String path) throws FileNotFoundException {
        Scanner scanner = new Scanner(new File(path));
        HashMap<String, List<String>> data = new HashMap<>();
        String[] tmp;
        while (scanner.hasNextLine()) {
            tmp = scanner.nextLine().split(",");
            if(!data.keySet().contains(tmp[tmp.length-1]))
                data.put(tmp[tmp.length - 1], new ArrayList<>());
            String st="";
            for (int i = 0; i < tmp.length-1; i++) {
                st+=tmp[i]+" ";
            }
            data.get(tmp[tmp.length - 1]).add(""+st);
        }
        return  data;
    }

    static List<TestRes> readTest(String path) throws FileNotFoundException {
        Scanner scanner = new Scanner(new File(path));
        ArrayList<TestRes> data = new ArrayList<>();
        String[] tmp;
        while (scanner.hasNextLine()) {
            tmp = scanner.nextLine().split(",");
            String st="";
            for (int i = 0; i < tmp.length-1; i++) {
                st+=tmp[i]+" ";
            }
            data.add(new TestRes(tmp[tmp.length-1],st));
        }
        return  data;
    }

    static TmpRes getSmallest(ArrayList<TmpRes> data){
        TmpRes res = data.get(0);
        for (int i = 1; i < data.size(); i++) {
            if(res.distace>data.get(i).distace) {
                res = data.get(i);
            }
        }
        data.remove(res);
        return res;
    }
}
