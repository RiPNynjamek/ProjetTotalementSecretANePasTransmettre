/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.pattern;

import com.mycompany.connection.Connect;
import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import org.json.JSONObject;
import com.google.gson.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author antoi
 */
@Stateless
@LocalBean
public class Route {
    private String message;
    private String key;
    private float confidence;
    private String resultString;
    public static boolean isDecrypted = false;
    private int i = 1;
    
    public void compare(){
        Mail mail = new Mail();        
        Dico dico = new Dico();

        while(!isDecrypted)
        {
            try {
                Thread.sleep(50);
            } catch (InterruptedException ex) {
                Logger.getLogger(Route.class.getName()).log(Level.SEVERE, null, ex);
            }
            if(i%1000 == 0)
            {
                System.out.println("Number of searches : " + i);
            }
            if(Connect.isReady && !Connect.QueueList.isEmpty())
            {
                i++;
                JSONObject json = new JSONObject(Connect.QueueList.get(0));
                message = json.getString("Message");
                key = json.getString("Key");
                String finalMail = mail.searchPattern(message, key);
                if (mail.isFound){
                    System.out.println("Mail found !");
                    dico.searchPattern(message, key);
                    confidence = dico.tauxConfiance;
                    if(confidence > 50 && !finalMail.isEmpty())
                    {
                        System.out.println("Success!");
                        isDecrypted = true;
                        Gson g = new Gson();
                        String jsonString = g.toJson(new Message(finalMail, key, confidence));
                        new Connect().send(jsonString);
                    }
                }
                Connect.QueueList.remove(0);
                if(key.equals("zzzzzz"))
                {
                    new Connect().send("");
                }
            }
        }
    }
    public String returnResult(){
        if(confidence <75){
        JSONObject result = new JSONObject();
        result.put("Mail" , message);
        result.put("Key", key);
        result.put("confidence", confidence);
        resultString = result.toString();
        System.out.println(resultString);
        }
        return resultString;
    }
}
