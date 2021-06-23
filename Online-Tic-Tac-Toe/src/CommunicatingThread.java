import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.SocketTimeoutException;

public class CommunicatingThread implements Runnable {
    private Socket client;
    BufferedReader br;
    Server server;

    boolean flag = true;
    public CommunicatingThread(Socket client,Server server) {
        super();
        this.client = client;
        this.server = server;
    }

    public void run(){
        try {
            Socket answer = new Socket(client.getInetAddress(),client.getPort());
            br = new BufferedReader(new InputStreamReader(client.getInputStream()));
            PrintWriter wr = new PrintWriter(answer.getOutputStream(),true);
            String tmp;
            while (flag) {
                tmp = br.readLine();
                if(tmp != null && !tmp.isEmpty()) {
                    switch (tmp){
                        case "LIST":
                            wr.println(server.data.toString());
                            break;
                        case "PLAY":
                            Server.lock.writeLock().lock();
                            server.gamers.add(client);
                            Server.lock.writeLock().unlock();
                            break;
                        case "LOGOUT":
                            server.clients.remove(client);
                            break;
                        default:
                            wr.println("Wrong command");
                            break;
                    }
                }
            }
            br.close();
        } catch(IOException e){
            e.printStackTrace();
        }
    }
}
