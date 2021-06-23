package base;

import java.io.*;
import java.net.*;

public class ProxyThread implements Runnable {
    private Socket client;
    BufferedReader br;
    public ProxyThread(Socket client) {
        super();
        this.client = client;
    }

    public void run(){
        ProxyTCPServer.counter++;
        try {
            br = new BufferedReader(new InputStreamReader(client.getInputStream()));
            Socket destination;
            boolean https = false;
            String urlAdress="";
            StringBuilder req=new StringBuilder();
            String tmp;
            tmp = br.readLine();
            String tab[];
            while (tmp != null && !tmp.isEmpty()) {
                if(tmp.startsWith("CONNECT")){
                    https=true;
                }
                else if (tmp.startsWith("Host:") ){
                    tab=tmp.split(":");
                    urlAdress=tab[1].trim();
                }
                else if(tmp.startsWith("Proxy-Connection:")){
                    tmp="Proxy-Connection: close";
                }
                req.append(tmp).append("\n");
                tmp=br.readLine();
            }
            req.append("\n");
            System.out.println(req.toString());
            if(!https) {
                destination = new Socket(urlAdress, 80);
                destination.getOutputStream().write(req.toString().getBytes());
                destination.getOutputStream().flush();
                transfer(destination,client);
                client.getOutputStream().flush();
                client.close();
                destination.close();
            }else{
                destination = new Socket(urlAdress, 443);
                client.getOutputStream().write("HTTP/1.0 200 Connection established\r\n Proxy-Agent: ProxyServer/1.0\r\n\r\n".getBytes());
                client.getOutputStream().flush();
                destination.setSoTimeout(5000);
                new Thread(()->{
                    try {
                        transfer(client, destination);

                    }catch (IOException ex){
                        ex.printStackTrace();
                    }
                }).start();
                transfer(destination, client);
                client.close();
                if (destination!=null)
                    destination.close();
            }
            br.close();
        } catch (SocketTimeoutException e) {
            try{
                client.getOutputStream().write("HTTP/1.0 504 Timeout Occured after 10s\nUser-Agent: ProxyServer/1.0\n\r\n".getBytes());
                client.getOutputStream().flush();
            } catch (IOException ioe) {
                ioe.printStackTrace();
            }
        }
        catch (IOException ignored) {}
        ProxyTCPServer.counter--;
    }

    private void transfer(Socket destination, Socket client) throws IOException {
        byte[] buffer = new byte[4096];
        int read;
        do {
            read = destination.getInputStream().read(buffer);
            if (read > 0) {
                client.getOutputStream().write(buffer, 0, read);
                if (destination.getInputStream().available() < 1) {
                    client.getOutputStream().flush();
                }
            }
        } while (read >= 0);
    }
}