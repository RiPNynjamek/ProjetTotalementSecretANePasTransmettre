/*
* To change this license header, choose License Headers in Project Properties.
* To change this template file, choose Tools | Templates
* and open the template in the editor.
*/
package com.gen.ejbpattern;

import javax.ejb.Stateless;
import javax.ejb.LocalBean;
import org.json.JSONObject;

/**
 *
 * @author Cyril
 */
@Stateless
@LocalBean
public class router {
    private String message;
    private String key;
    private float confidence;
    private String resultString;
    public void compare(String object){
        JSONObject json = new JSONObject(object);
        System.out.println(json);
        message = json.getString("Message");
        key = json.getString("key");
        patternMail mail = new patternMail();
        patternDico dico = new patternDico();
        mail.searchPattern(message);
        if (mail.getMailFinded()){
            dico.searchPattern(message);
            float confidence = dico.getTauxConfiance();
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
    
    
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
}
